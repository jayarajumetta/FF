using ToscaModernized.Core.Models;

namespace ToscaModernized.Core.Execution;

public sealed class ExecutionRequest
{
    public required PlanInstruction Instruction { get; init; }
    public IReadOnlyList<IReadOnlyList<string>> RuntimeTable { get; init; } = Array.Empty<IReadOnlyList<string>>();
}
