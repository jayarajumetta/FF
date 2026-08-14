using Reqnroll;
using ToscaArtifactAutomation.Core.Application;

namespace ToscaArtifactAutomation.Tests.Shared.Bindings;

[Binding]
public sealed class ApplicationSessionSteps
{
    private readonly ApplicationSessionService _session;
    public ApplicationSessionSteps(ApplicationSessionService session) => _session = session ?? throw new ArgumentNullException(nameof(session));

    [Given("^the \"([^\"]+)\" application is configured for browser \"([^\"]+)\"$")]
    public void ConfigureApplication(string application, string browser) => _session.ValidateApplication(application, browser);

    [Given("^an authenticated \"([^\"]+)\" session is available$")]
    public Task EnsureAuthenticatedSessionAsync(string application) => _session.EnsureAuthenticatedAsync(application);
}
