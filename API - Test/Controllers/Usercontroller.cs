using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Core.AppService.Service;
using API.Core.Entity;
using API.Core.AppService;

namespace API___Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Usercontroller : Controller
    {
        private readonly IUserService _userService;
        public Usercontroller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            return _userService.ReadyById(id);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            try
            {
                return Ok(_userService.createUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.id)  return BadRequest("Wrong parameter ID");
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete ("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            return _userService.deleteUser(id);
        }

    }
}
