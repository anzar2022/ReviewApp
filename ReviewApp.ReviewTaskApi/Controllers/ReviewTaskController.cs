using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.IServices;
using ReviewApp.Model;
using System.Threading.Tasks;

namespace ReviewApp.ReviewTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<ReviewTask>> CreateReviewTask([FromBody] CreateReviewTaskDto task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            await _reviewTaskService.AddReviewTaskAsync(task);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReviewTask(long Id, [FromBody] UpdateReviewTaskDto taskDto)
        {
            if (Id != taskDto.Id)
            {
                return BadRequest();
            }

            var existingTask = await _reviewTaskService.GetReviewTaskByIdAsync(Id);
            if (existingTask == null)
            {
                return NotFound();
            }

            await _reviewTaskService.UpdateReviewTaskAsync(Id, taskDto);
            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReviewTask(long Id)
        {
            try
            {
                var task = await _reviewTaskService.GetReviewTaskByIdAsync(Id);

                if (task == null)
                {
                    return NotFound();
                }

                await _reviewTaskService.DeleteReviewTaskAsync(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning a 500 Internal Server Error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [Route("GetWeightageSumByQuarterId/{Id:int}")]
        public async Task<int> GetWeightageSumByQuarterIdAsync(int Id)
        {
            try
            {
                int weightage = await _reviewTaskService.GetWeightageSumByQuarterIdAsync(Id);

                if (weightage == 0)
                {
                    return 0;
                }

                return weightage;
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning 0 as a default value in case of an exception
                return 0;
            }
        }
        [Route("UpdateReviewTaskStartDateAsync1/{Id:long}/{TaskStartDate:DateOnly}")]
        public async Task<ActionResult> UpdateReviewTaskStartDateAsync1(long Id, DateOnly TaskStartDate )
        {
            try
            {
                var  reviewTask = await _reviewTaskService.UpdateReviewTaskStartDateAsync(Id,  TaskStartDate);

                return Ok(reviewTask);

               
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning 0 as a default value in case of an exception
                throw;
            }
        }
        [HttpPost("UpdateReviewTaskStartDateAsync")]
        public async Task<ActionResult> UpdateReviewTaskStartDateAsync(UpdateTaskStartDateDto updateTaskStartDateDto)
        {
            try
            {
                var reviewTask = await _reviewTaskService.UpdateReviewTaskStartDateAsync(updateTaskStartDateDto.Id, updateTaskStartDateDto.TaskStartDate);

                return Ok(reviewTask);


            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning 0 as a default value in case of an exception
                throw;
            }
        }
        [HttpPost("UpdateReviewTaskCompleteDateAsync")]
        public async Task<ActionResult> UpdateReviewTaskCompleteDateAsync(UpdateTaskCompleteDateDto updateTaskCompleteDateDto)
        {
            try
            {
                var reviewTask = await _reviewTaskService.UpdateReviewTaskCompleteDateAsync(updateTaskCompleteDateDto.Id, updateTaskCompleteDateDto.TaskCompleteDate);

                return Ok(reviewTask);


            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning 0 as a default value in case of an exception
                throw;
            }
        }
        [HttpPost("UpdateReviewTaskCancelAsync/{Id:long}")]
        public async Task<ActionResult> UpdateReviewTaskCancelAsync(long Id)
        {
            try
            {
                var reviewTask = await _reviewTaskService.UpdateReviewTaskCancelAsync(Id);

                return Ok(reviewTask);


            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary actions
                // For demonstration purposes, returning 0 as a default value in case of an exception
                throw;
            }
        }

    }
}
