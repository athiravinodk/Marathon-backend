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
        UserDbContext dbconnection;
        public UserController(UserDbContext UserDbContext)
        {
            dbconnection = UserDbContext;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                dbconnection.UserModels.Add(userObj);
                dbconnection.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = " user added  successfully"
                });
            }
        }
    }
}
