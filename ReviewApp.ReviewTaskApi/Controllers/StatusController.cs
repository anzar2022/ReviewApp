
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.IServices;
using ReviewApp.Model;

namespace ReviewApp.ReviewTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService ?? throw new ArgumentNullException(nameof(statusService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatuses()
        {
            var statuses = await _statusService.GetAllStatusesAsync();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var status = await _statusService.GetStatusByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus([FromBody] Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            await _statusService.AddStatusAsync(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            var existingStatus = await _statusService.GetStatusByIdAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            await _statusService.UpdateStatusAsync(status);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            var status = await _statusService.GetStatusByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            await _statusService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
