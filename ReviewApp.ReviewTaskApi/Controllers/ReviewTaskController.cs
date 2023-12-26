using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.IServices;
using ReviewApp.Model;

namespace ReviewApp.ReviewTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewTaskController : ControllerBase
    {
        private readonly IReviewTaskService _reviewTaskService;

        public ReviewTaskController(IReviewTaskService reviewTaskService)
        {
            _reviewTaskService = reviewTaskService ?? throw new ArgumentNullException(nameof(reviewTaskService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewTask>>> GetAllReviewTasks()
        {
            var tasks = await _reviewTaskService.GetAllReviewTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewTask>> GetReviewTaskById(long Id)
        {
            var task = await _reviewTaskService.GetReviewTaskByIdAsync(Id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewTask>> CreateReviewTask([FromBody] ReviewTask task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            await _reviewTaskService.AddReviewTaskAsync(task);
            return CreatedAtAction(nameof(GetReviewTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReviewTask(long Id, [FromBody] ReviewTask task)
        {
            if (Id != task.Id)
            {
                return BadRequest();
            }

          

            await _reviewTaskService.UpdateReviewTaskAsync(Id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReviewTask(long Id)
        {
            var task = await _reviewTaskService.GetReviewTaskByIdAsync(Id);

            if (task == null)
            {
                return NotFound();
            }

            await _reviewTaskService.DeleteReviewTaskAsync(Id);
            return NoContent();
        }
    }
}
