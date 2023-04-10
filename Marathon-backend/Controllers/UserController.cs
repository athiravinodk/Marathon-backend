using Marathon_backend.Data;
using Marathon_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Marathon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext Dbcontext;
        public UserController(UserDbContext UserDbContext)
        {
            this.Dbcontext = UserDbContext;
        }

        [HttpGet("get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("add")]
             public void Post([FromBody] string value) { }
        public async Task<HttpStatusCode> Add(UserModel User)
        {
            var entity = new UserModel()
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Age = User.Age,
                Gender = User.Gender,
                Category = User.Category,
                ContactNumber = User.ContactNumber,
            };
            Dbcontext.UserModels.Add(entity);
            await Dbcontext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

    }
}
