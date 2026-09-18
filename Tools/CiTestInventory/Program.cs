using System.Reflection;
using System.Runtime.Loader;
using System.Globalization;
using System.Text.Json;

if (args.Length != 2)
{
    Console.Error.WriteLine(
        "Usage: CiTestInventory <test-assembly> <output-json>");
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
            modules
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
        $"Test inventory generation failed: {exception.Message}");
    return 1;
}

return 0;

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
                        .Concat(caseCategories)));
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
    IEnumerable<string> categories)
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
            .ToArray());
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
    IReadOnlyList<string> Categories);

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
