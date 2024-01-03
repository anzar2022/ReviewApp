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
    public class QuarterController : ControllerBase
    {
        private readonly IQuarterService _quarterService;

        public QuarterController(IQuarterService quarterService)
        {
            _quarterService = quarterService ?? throw new ArgumentNullException(nameof(quarterService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarter>>> GetAllQuarters()
        {
            var quarters = await _quarterService.GetAllQuartersAsync();
            return Ok(quarters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quarter>> GetQuarterById(int id)
        {
            var quarter = await _quarterService.GetQuarterByIdAsync(id);

            if (quarter == null)
            {
                return NotFound();
            }

            return Ok(quarter);
        }

        [HttpPost]
        public async Task<ActionResult<Quarter>> CreateQuarter([FromBody] Quarter quarter)
        {
            if (quarter == null)
            {
                return BadRequest();
            }

            await _quarterService.AddQuarterAsync(quarter);
            return CreatedAtAction(nameof(GetQuarterById), new { id = quarter.Id }, quarter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuarter(int id, [FromBody] Quarter quarter)
        {
            if (id != quarter.Id)
            {
                return BadRequest();
            }

            var existingQuarter = await _quarterService.GetQuarterByIdAsync(id);
            if (existingQuarter == null)
            {
                return NotFound();
            }

            await _quarterService.UpdateQuarterAsync(quarter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuarter(int id)
        {
            var quarter = await _quarterService.GetQuarterByIdAsync(id);

            if (quarter == null)
            {
                return NotFound();
            }

            await _quarterService.DeleteQuarterAsync(id);
            return NoContent();
        }
    }
}
