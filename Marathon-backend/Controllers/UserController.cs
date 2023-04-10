using Marathon_backend.DTO;
using Marathon_backend.Entities;
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
        private readonly UserDbContext userDbContext;
        public UserController(UserDbContext UserDbContext)
        {
            this.userDbContext = UserDbContext;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await userDbContext.registered_users.Select(
                UserModel => new UserDTO
                {
                    Id = UserModel.Id,
                    FirstName = UserModel.FirstName,
                    LastName = UserModel.LastName,
                    Age = UserModel.Age,
                    Gender = UserModel.Gender,
                    Category = UserModel.Category,
                    ContactNumber = UserModel.ContactNumber
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpPost("add")]
        public async Task<HttpStatusCode> Add(UserDTO UserModel)
        {
            var entity = new UserModel()
            {
                Id = UserModel.Id,       
                FirstName = UserModel.FirstName,
                LastName = UserModel.LastName,
                Age = UserModel.Age,
                Gender = UserModel.Gender,
                Category = UserModel.Category,
                ContactNumber = UserModel.ContactNumber,
            };
            userDbContext.registered_users.Add(entity);
            await userDbContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

    }
}
