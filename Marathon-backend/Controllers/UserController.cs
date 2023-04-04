using Marathon_backend.Data;
using Marathon_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marathon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext UserDbContext)
        {
            _context = UserDbContext;
        }

        [HttpPost("add_user")]
        public IActionResult AddUser([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.UserModels.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = " user Created  successfully"
                });
            }
        }
    }
}
