using System.Reflection;
using System.Runtime.Loader;
using System.Globalization;
using System.Text.Json;

if (args.Length > 0 && args[0] == "initialize-sgs-ledger")
    return SgsLedgerInitializer.Run(args[1..]);

if (args.Length is not (2 or 4))
{
    Console.Error.WriteLine(
        "Usage: CiTestInventory <test-assembly> <output-json> [<readiness-matrix> <package-root>]");
    return 2;
}

var assemblyPath = Path.GetFullPath(args[0]);
var outputPath = Path.GetFullPath(args[1]);
if (!File.Exists(assemblyPath))
{
    Console.Error.WriteLine($"Test assembly '{assemblyPath}' does not exist.");
    return 2;
}

try
{
    var context = new InspectionLoadContext(assemblyPath);
    try
    {
        var assembly = context.LoadFromAssemblyPath(assemblyPath);
        var tests = Discover(assembly);
        var modules = DiscoverModules(assembly);
        if (tests.Count == 0)
            throw new InvalidOperationException(
                "Compiled test assembly contains no NUnit tests.");
        if (modules.Count == 0)
            throw new InvalidOperationException(
                "Compiled test assembly contains no product modules.");
        var duplicates = tests
            .GroupBy(test => test.Id, StringComparer.Ordinal)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToArray();
        if (duplicates.Length > 0)
            throw new InvalidOperationException(
                $"Compiled test inventory contains duplicate identities: {string.Join(", ", duplicates)}.");

        Directory.CreateDirectory(
            Path.GetDirectoryName(outputPath)
            ?? throw new InvalidOperationException("Inventory output has no parent."));
        var inventory = new
        {
            schemaVersion = 1,
            assembly = Path.GetFileName(assemblyPath),
            count = tests.Count,
            tests,
            modules,
            profileAdmissions = args.Length == 4
                ? DiscoverProfileAdmissions(assembly, tests, args[2], args[3])
                : []
        };
        File.WriteAllText(
            outputPath,
            JsonSerializer.Serialize(
                inventory,
                new JsonSerializerOptions { WriteIndented = true }));
    }
    finally
    {
        context.Unload();
    }
}
catch (Exception exception)
{
    Console.Error.WriteLine(
        $"Test inventory generation failed: {exception.GetBaseException().Message}");
    return 1;
}

return 0;

static List<WorkflowProfileAdmission> DiscoverProfileAdmissions(
    Assembly assembly,
    IReadOnlyList<TestInventoryEntry> tests,
    string matrixPath,
    string packageRoot)
{
    using var matrix = JsonDocument.Parse(File.ReadAllText(matrixPath));
    if (matrix.RootElement.GetProperty("schemaVersion").GetInt32() != 2)
        throw new InvalidOperationException("Unsupported integration readiness schema.");

    // Use the provider from the inspected test assembly, not the tool's copy or a
    // second implementation of its checksum, expiry, and selection rules.
    var optionsType = assembly.GetType(
        "PnCTestAutomation.BusinessOutcomes.BusinessOutcomeOptions", throwOnError: true)!;
    var providerType = assembly.GetType(
        "PnCTestAutomation.BusinessOutcomes.ExpectedOutcomeProfileProvider", throwOnError: true)!;
    var resolve = providerType.GetMethod(
        "ResolvePreflight", [typeof(string), typeof(string), typeof(string)])
        ?? throw new InvalidOperationException("Compiled profile resolver is missing.");
    var root = Path.GetFullPath(packageRoot).TrimEnd(Path.DirectorySeparatorChar)
               + Path.DirectorySeparatorChar;
    var reports = new List<WorkflowProfileAdmission>();
    foreach (var workflow in matrix.RootElement.GetProperty("workflows").EnumerateArray())
    {
        var id = workflow.GetProperty("workflowId").GetString()!;
        var profile = workflow.GetProperty("profile");
        if (profile.GetProperty("status").GetString() != "PerCase")
            throw new InvalidOperationException($"Workflow '{id}' requires PerCase profile admission.");
        var catalogPath = Path.GetFullPath(Path.Combine(
            root, profile.GetProperty("catalogPath").GetString()!.Replace('/', Path.DirectorySeparatorChar)));
        if (!catalogPath.StartsWith(root, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"Workflow '{id}' profile catalog is outside the package.");
        var options = Activator.CreateInstance(optionsType)!;
        optionsType.GetProperty("ProfilePath")!.SetValue(options, catalogPath);
        var provider = Activator.CreateInstance(providerType, [options])
                       ?? throw new InvalidOperationException("Compiled profile provider could not be created.");
        var categories = workflow.GetProperty("discoveryCategories").EnumerateArray()
            .Select(item => item.GetString()!).ToArray();
        var selected = tests.Where(test => categories.All(category =>
            test.Categories.Contains(category, StringComparer.OrdinalIgnoreCase))).ToArray();
        var environments = profile.GetProperty("environments").EnumerateArray()
            .Select(item => item.GetString()!).ToArray();
        if (categories.Length == 0 || selected.Length == 0 || environments.Length == 0 ||
            environments.Any(string.IsNullOrWhiteSpace) ||
            environments.Distinct(StringComparer.OrdinalIgnoreCase).Count() != environments.Length)
            throw new InvalidOperationException($"Workflow '{id}' has empty or duplicate admission scope.");
        var cases = new List<CaseProfileAdmission>();
        foreach (var test in selected)
        {
            if (string.IsNullOrWhiteSpace(test.State))
                throw new InvalidOperationException($"Compiled test '{test.Id}' has no state argument.");
            foreach (var environment in environments)
            {
                var resolution = resolve.Invoke(provider,
                    [profile.GetProperty("profileId").GetString()!, environment, test.State])
                    ?? throw new InvalidOperationException("Compiled profile resolution is missing.");
                var resolvedProfile = RequiredProperty(resolution, "Profile");
                cases.Add(new CaseProfileAdmission(
                    test.Id, environment, test.State,
                    RequiredString(resolvedProfile, "ProfileId"),
                    RequiredString(resolvedProfile, "Mode"),
                    RequiredBoolean(resolution, "IsRunnable"),
                    RequiredString(resolution, "Reason")));
            }
        }
        reports.Add(new WorkflowProfileAdmission(id, cases));
    }
    return reports;
}

static List<ProductModuleInventoryEntry> DiscoverModules(Assembly assembly)
{
    var moduleInterface = assembly.GetType(
        "PnCTestAutomation.Products.IProductModule",
        throwOnError: true)
        ?? throw new InvalidOperationException(
            "Product module contract was not found.");
    var modules = new List<ProductModuleInventoryEntry>();
    foreach (var type in assembly.GetTypes()
                 .Where(type =>
                     !type.IsAbstract &&
                     !type.IsInterface &&
                     moduleInterface.IsAssignableFrom(type))
                 .OrderBy(type => type.FullName, StringComparer.Ordinal))
    {
        var instance = Activator.CreateInstance(type)
                       ?? throw new InvalidOperationException(
                           $"Product module '{type.FullName}' could not be created.");
        var descriptor = RequiredProperty(instance, "Descriptor");
        var evidence = RequiredProperty(descriptor, "Evidence");
        modules.Add(new ProductModuleInventoryEntry(
            RequiredString(descriptor, "ModuleId"),
            RequiredString(descriptor, "Product"),
            RequiredString(descriptor, "Workflow"),
            RequiredStrings(descriptor, "AutomationIdFamilies"),
            RequiredStrings(descriptor, "RequiredCapabilities"),
            RequiredString(descriptor, "DataProfileId"),
            new ProductEvidenceInventory(
                RequiredStrings(evidence, "RequiredArtifacts"),
                RequiredBoolean(evidence, "RequiresCanonicalResult"),
                RequiredBoolean(evidence, "RequiresFailureTrace"),
                RequiredBoolean(evidence, "RequiresFailureVideo")),
            RequiredStrings(descriptor, "SelectorExceptionReferences"),
            RequiredStrings(descriptor, "BlockedSelectors"),
            RequiredBoolean(descriptor, "RetrySafe")));
    }
    return modules;
}

static object RequiredProperty(object instance, string name) =>
    instance.GetType().GetProperty(name)?.GetValue(instance)
    ?? throw new InvalidOperationException(
        $"Compiled contract '{instance.GetType().FullName}.{name}' is missing.");

static string RequiredString(object instance, string name) =>
    RequiredProperty(instance, name).ToString()
    ?? throw new InvalidOperationException(
        $"Compiled contract '{instance.GetType().FullName}.{name}' is empty.");

static bool RequiredBoolean(object instance, string name) =>
    RequiredProperty(instance, name) is bool value
        ? value
        : throw new InvalidOperationException(
            $"Compiled contract '{instance.GetType().FullName}.{name}' is not Boolean.");

static IReadOnlyList<string> RequiredStrings(object instance, string name)
{
    if (RequiredProperty(instance, name) is not System.Collections.IEnumerable values)
    {
        throw new InvalidOperationException(
            $"Compiled contract '{instance.GetType().FullName}.{name}' is not enumerable.");
    }
    return values.Cast<object>()
        .Select(value => value.ToString() ?? "")
        .ToArray();
}

static List<TestInventoryEntry> Discover(Assembly assembly)
{
    var results = new List<TestInventoryEntry>();
    foreach (var type in assembly.GetTypes().OrderBy(type => type.FullName))
    {
        var fixtureCategories = GetDirectCategories(
            type.GetCustomAttributesData());
        foreach (var method in type.GetMethods(
                     BindingFlags.Instance |
                     BindingFlags.Static |
                     BindingFlags.Public |
                     BindingFlags.NonPublic))
        {
            var attributes = method.GetCustomAttributesData();
            var methodCategories = GetDirectCategories(attributes);
            var testCases = attributes
                .Where(attribute =>
                    attribute.AttributeType.FullName ==
                    "NUnit.Framework.TestCaseAttribute")
                .ToArray();
            var isTest = attributes.Any(attribute =>
                attribute.AttributeType.FullName ==
                "NUnit.Framework.TestAttribute");

            if (testCases.Length == 0 && !isTest)
                continue;

            if (testCases.Length == 0)
            {
                results.Add(CreateEntry(
                    type,
                    method,
                    0,
                    false,
                    method.Name,
                    fixtureCategories.Concat(methodCategories)));
                continue;
            }

            for (var index = 0; index < testCases.Length; index++)
            {
                var caseCategories = GetTestCaseCategories(testCases[index]);
                results.Add(CreateEntry(
                    type,
                    method,
                    index,
                    true,
                    GetDisplayName(method, testCases[index]),
                    fixtureCategories
                        .Concat(methodCategories)
                        .Concat(caseCategories),
                    GetStateArgument(method, testCases[index])));
            }
        }
    }

    return results;
}

static TestInventoryEntry CreateEntry(
    Type type,
    MethodInfo method,
    int caseIndex,
    bool parameterized,
    string displayName,
    IEnumerable<string> categories,
    string? state = null)
{
    var typeName = type.FullName
                   ?? throw new InvalidOperationException(
                       "A discovered test type has no full name.");
    return new TestInventoryEntry(
        $"{typeName}.{method.Name}#{caseIndex:D4}",
        typeName,
        method.Name,
        parameterized,
        displayName,
        categories
            .Where(category => !string.IsNullOrWhiteSpace(category))
            .Select(category => category.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(category => category, StringComparer.OrdinalIgnoreCase)
            .ToArray(),
        state);
}

static string? GetStateArgument(MethodInfo method, CustomAttributeData testCase)
{
    var arguments = testCase.ConstructorArguments;
    if (arguments.Count == 1 &&
        arguments[0].Value is IEnumerable<CustomAttributeTypedArgument> items)
        arguments = items.ToArray();
    var parameters = method.GetParameters();
    foreach (var name in new[] { "stateAbbv", "stateCode", "state" })
    {
        var index = Array.FindIndex(parameters, parameter =>
            string.Equals(parameter.Name, name, StringComparison.OrdinalIgnoreCase));
        if (index < 0 || index >= arguments.Count ||
            arguments[index].Value is not string value || string.IsNullOrWhiteSpace(value))
            continue;
        value = value.Trim();
        if (name != "state" || value.Length == 2)
            return value.ToUpperInvariant();
    }
    return null;
}

static string GetDisplayName(
    MethodInfo method,
    CustomAttributeData testCase)
{
    var configuredName = testCase.NamedArguments.FirstOrDefault(
        argument => argument.MemberName == "TestName").TypedValue.Value as string;
    if (!string.IsNullOrWhiteSpace(configuredName))
        return configuredName;

    var arguments = testCase.ConstructorArguments;
    if (arguments.Count == 1 &&
        arguments[0].Value is IEnumerable<CustomAttributeTypedArgument> items)
    {
        arguments = items.ToArray();
    }

    return $"{method.Name}({string.Join(",", arguments.Select(FormatArgument))})";
}

static string FormatArgument(CustomAttributeTypedArgument argument)
{
    if (argument.Value is null)
        return "null";
    if (argument.Value is string text)
        return $"\"{text.Replace("\\", "\\\\").Replace("\"", "\\\"")}\"";
    if (argument.Value is char character)
        return $"'{character}'";
    if (argument.Value is bool boolean)
        return boolean ? "True" : "False";
    if (argument.Value is IEnumerable<CustomAttributeTypedArgument> items)
        return $"[{string.Join(", ", items.Select(FormatArgument))}]";
    if (argument.ArgumentType.IsEnum)
        return Enum.GetName(argument.ArgumentType, argument.Value)
               ?? Convert.ToString(argument.Value, CultureInfo.InvariantCulture)
               ?? "";

    return Convert.ToString(argument.Value, CultureInfo.InvariantCulture) ?? "";
}

static IEnumerable<string> GetDirectCategories(
    IEnumerable<CustomAttributeData> attributes)
{
    foreach (var attribute in attributes.Where(attribute =>
                 attribute.AttributeType.FullName ==
                 "NUnit.Framework.CategoryAttribute"))
    {
        if (attribute.ConstructorArguments.Count == 1 &&
            attribute.ConstructorArguments[0].Value is string category)
        {
            yield return category;
        }
    }

}

static IEnumerable<string> GetTestCaseCategories(
    CustomAttributeData attribute)
{
    var categoryArgument = attribute.NamedArguments.FirstOrDefault(
        argument => argument.MemberName == "Category");
    if (categoryArgument.TypedValue.Value is not string categories)
        yield break;

    foreach (var category in categories.Split(
                 ',',
                 StringSplitOptions.RemoveEmptyEntries |
                 StringSplitOptions.TrimEntries))
    {
        yield return category;
    }
}

sealed record TestInventoryEntry(
    string Id,
    string ClassName,
    string MethodName,
    bool Parameterized,
    string DisplayName,
    IReadOnlyList<string> Categories,
    string? State);

sealed record WorkflowProfileAdmission(
    string WorkflowId,
    IReadOnlyList<CaseProfileAdmission> Cases);

sealed record CaseProfileAdmission(
    string TestId,
    string Environment,
    string State,
    string ProfileId,
    string Mode,
    bool IsRunnable,
    string Reason);

sealed record ProductModuleInventoryEntry(
    string ModuleId,
    string Product,
    string Workflow,
    IReadOnlyList<string> AutomationIdFamilies,
    IReadOnlyList<string> RequiredCapabilities,
    string DataProfileId,
    ProductEvidenceInventory Evidence,
    IReadOnlyList<string> SelectorExceptionReferences,
    IReadOnlyList<string> BlockedSelectors,
    bool RetrySafe);

sealed record ProductEvidenceInventory(
    IReadOnlyList<string> RequiredArtifacts,
    bool RequiresCanonicalResult,
    bool RequiresFailureTrace,
    bool RequiresFailureVideo);

sealed class InspectionLoadContext : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;

    public InspectionLoadContext(string assemblyPath)
        : base(isCollectible: true)
    {
        _resolver = new AssemblyDependencyResolver(assemblyPath);
    }

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        var path = _resolver.ResolveAssemblyToPath(assemblyName);
        return path == null ? null : LoadFromAssemblyPath(path);
    }
}
