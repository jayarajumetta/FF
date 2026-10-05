#requires -Version 7.4

function Get-FormsValidationRuntime {
    $assemblyPath = [IO.Path]::GetFullPath(
        (Join-Path $PSScriptRoot "..\bin\Debug\net8.0\TestAutomation.dll"))
    if (-not (Test-Path -LiteralPath $assemblyPath)) {
        throw "Build the active solution in Visual Studio (Debug) before using JSON forms tools."
    }

    # Isolate application packages from PowerShell's own System.Text.Json version.
    if (-not ("PnCFormsTools.RuntimeLoader" -as [type])) {
        Add-Type -TypeDefinition @'
using System.Reflection;
using System.Runtime.Loader;
namespace PnCFormsTools
{
    public sealed class RuntimeLoader : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;
        private RuntimeLoader(string path) : base(isCollectible: true)
        {
            resolver = new AssemblyDependencyResolver(path);
        }
        protected override Assembly Load(AssemblyName name)
        {
            var path = resolver.ResolveAssemblyToPath(name);
            return path == null ? null : LoadFromAssemblyPath(path);
        }
        public static Assembly Open(string path)
        {
            return new RuntimeLoader(path).LoadFromAssemblyPath(path);
        }
    }
}
'@
    }
    $assembly = [PnCFormsTools.RuntimeLoader]::Open($assemblyPath)
    $config = [Activator]::CreateInstance(
        $assembly.GetType("PnCTestAutomation.Models.DuckCreekFormsConfig", $true))
    $validator = [Activator]::CreateInstance(
        $assembly.GetType("PnCTestAutomation.Services.FormsValidationService", $true),
        [object[]]@($config))
    [pscustomobject]@{ Assembly = $assembly; Validator = $validator }
}
