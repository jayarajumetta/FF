using System.CodeDom;
using Reqnroll.Generator;
using Reqnroll.Generator.CodeDom;
using Reqnroll.Generator.Plugins;
using Reqnroll.Generator.UnitTestProvider;
using Reqnroll.Infrastructure;
using Reqnroll.UnitTestProvider;

[assembly: GeneratorPlugin(typeof(InsuranceAutomation.Retry.Generator.RetryGeneratorPlugin))]

namespace InsuranceAutomation.Retry.Generator;

public sealed class RetryGeneratorPlugin : IGeneratorPlugin
{
    public void Initialize(GeneratorPluginEvents events, GeneratorPluginParameters parameters, UnitTestProviderConfiguration configuration)
    {
        events.CustomizeDependencies += (_, args) =>
            args.ObjectContainer.RegisterTypeAs<RetryTestGeneratorProvider, IUnitTestGeneratorProvider>();
    }
}

public sealed class RetryTestGeneratorProvider : NUnit3TestGeneratorProvider
{
    public RetryTestGeneratorProvider(CodeDomHelper helper) : base(helper) { }

    public override void FinalizeTestClass(TestClassGenerationContext context)
    {
        base.FinalizeTestClass(context);
        if (context.TestClass.Name is "WCBasicPolicyFeature")
            return;

        foreach (CodeTypeMember member in context.TestClass.Members)
        {
            if (member is not CodeMemberMethod method) continue;
            var isTest = false;
            foreach (CodeAttributeDeclaration attribute in method.CustomAttributes)
            {
                if (attribute.Name is "NUnit.Framework.TestAttribute" or "NUnit.Framework.TestCaseAttribute" or
                    "NUnit.Framework.Test" or "NUnit.Framework.TestCase")
                    isTest = true;
            }
            if (isTest)
                method.CustomAttributes.Add(new CodeAttributeDeclaration("InsuranceAutomation.NUnit.ConfiguredRetryAttribute"));
        }
    }
}
