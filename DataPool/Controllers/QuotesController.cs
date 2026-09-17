using DataPool.Models;
using DataPool.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataPool.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public sealed class QuotesController : ControllerBase
    {
        private readonly IDataPoolService _service;

        public QuotesController(IDataPoolService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] string? status,
            [FromQuery] bool? isCommittedReferral,
            [FromQuery] string? transaction,
            [FromQuery] string? lob,
            [FromQuery] string? sfpVariant) =>
            Execute(() => _service.GetAll(
                status,
                isCommittedReferral,
                transaction,
                lob,
                sfpVariant));

        [HttpGet("available")]
        public IActionResult GetAvailable() =>
            Execute(_service.GetAvailable);

        [HttpPost]
        public IActionResult Add([FromBody] QuoteRecord record) =>
            Execute(() => _service.Add(record));

        [HttpPost("{id}/claim")]
        public IActionResult Claim(string id, [FromBody] UserActionRequest request) =>
            Execute(() => _service.Claim(id, request.Username));

        [HttpPost("{id}/consume")]
        public IActionResult Consume(string id, [FromBody] UserActionRequest request) =>
            Execute(() => _service.Consume(id, request.Username));

        [HttpPost("{id}/release")]
        public IActionResult Release(string id) =>
            Execute(() => _service.Release(id));

        [HttpDelete("cleanup")]
        public IActionResult Cleanup(
            [FromQuery] int consumedDaysOld = 30,
            [FromQuery] int availableDaysOld = 90) =>
            Execute(() =>
            {
                var result = _service.CleanupOldRecords(
                    consumedDaysOld,
                    availableDaysOld);
                return new
                {
                    removedConsumed = result.RemovedConsumed,
                    removedAvailable = result.RemovedAvailable
                };
            });

        private IActionResult Execute<T>(Func<T> operation)
        {
            try
            {
                return Ok(operation());
            }
            catch (DataPoolValidationException exception)
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "Invalid DataPool request",
                    detail: exception.Message);
            }
            catch (KeyNotFoundException)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Quote not found");
            }
            catch (DataPoolConflictException exception)
            {
                return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Invalid quote state transition",
                    detail: exception.Message);
            }
            catch (DataPoolStorageException)
            {
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "DataPool storage is unavailable");
            }
        }
    }

    public sealed record UserActionRequest(string Username);
}
