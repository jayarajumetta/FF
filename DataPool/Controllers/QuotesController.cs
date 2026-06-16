using DataPool.Models;
using DataPool.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataPool.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly IDataPoolService _service;

        public QuotesController(IDataPoolService service)
            => _service = service;

        // GET /api/quotes?status=available&type=Quote&isCommittedReferral=true&lob=SFP&sfpVariant=CE
        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] string? status,
            [FromQuery] bool? isCommittedReferral,
            [FromQuery] string? type,
            [FromQuery] string? lob,
            [FromQuery] string? sfpVariant)
            => Ok(_service.GetAll(status, isCommittedReferral, type, lob, sfpVariant));

        // GET /api/quotes/available
        [HttpGet("available")]
        public IActionResult GetAvailable()
            => Ok(_service.GetAvailable());

        // POST /api/quotes  — used by automation to seed data
        [HttpPost]
        public IActionResult Add([FromBody] QuoteRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.Id))
                return BadRequest("Quote ID is required.");
            try
            {
                return Ok(_service.Add(record));
            }
            catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        }

        // POST /api/quotes/{id}/claim
        [HttpPost("{id}/claim")]
        public IActionResult Claim(string id, [FromBody] UserActionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
                return BadRequest("Username is required.");
            try
            {
                return Ok(_service.Claim(id, request.Username));
            }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        }

        // POST /api/quotes/{id}/consume
        [HttpPost("{id}/consume")]
        public IActionResult Consume(string id, [FromBody] UserActionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
                return BadRequest("Username is required.");
            try
            {
                return Ok(_service.Consume(id, request.Username));
            }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        }

        // POST /api/quotes/{id}/release
        [HttpPost("{id}/release")]
        public IActionResult Release(string id)
        {
            try
            {
                return Ok(_service.Release(id));
            }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        }
    }

    public record UserActionRequest(string Username);
}
