using Microsoft.AspNetCore.Mvc;
using ReviewApp.IServices;
using ReviewApp.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReviewApp.ReviewTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
             var users =  await _userService.GetUsers();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int Id)
        {
            var user = await _userService.GetUserById(Id);

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            var newUser = await _userService.CreateUser(user);

            return Ok(newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> Put(int Id, [FromBody] User  user)
        {
            var updated = await _userService.UpdateUser(Id, user);

            return Ok(updated);


        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int Id)
        {
            var isDeleted = await _userService.DeleteUser(Id);
            
            return Ok(isDeleted);
        }
    }
}
