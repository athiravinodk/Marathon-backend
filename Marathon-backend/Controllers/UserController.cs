using Azure;
using Marathon_backend.DTO;
using Marathon_backend.Entities;
using Marathon_backend.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
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
            ISingleModelResponse<UserDbContext> response = new SingleModelResponse<UserDbContext>();
            try
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
                    response.IsError = true;
                    response.ErrorMessage = "Invalid request";
                    return Ok(response);
                }
                else
                {
                    return List;
                }
            }
            catch (Exception)
            {

                response.IsError = true;
                response.ErrorMessage = "An error occured. Please contact to admin";
                return BadRequest(response);
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> Adduser(UserDTO UserModel)
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
            ISingleModelResponse<UserModel> response = new SingleModelResponse<UserModel>();
            try
            {
                userDbContext.registered_users.Add(entity);
                await userDbContext.SaveChangesAsync();
                response.IsError = false;
                response.ErrorMessage = "user added successfully";
                return Ok(response);
            }
            catch
            {
                response.IsError = true;
                response.ErrorMessage = "An error occurred. Please contact the admin.";
                return BadRequest(response);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel userModel)
        {
            ISingleModelResponse<UserModel> response = new SingleModelResponse<UserModel>();
            try
            {
                var existingUser = await userDbContext.registered_users.FirstOrDefaultAsync(u => u.Id == id);
                if (existingUser == null)
                {
                    response.IsError = true;
                    response.ErrorMessage = "User not found";
                    return NotFound(response);
                }
                existingUser.Time = userModel.Time;
                await userDbContext.SaveChangesAsync();
                response.IsError = false;
                response.ErrorMessage = "time added";
                return Ok(response);

            }
            catch (Exception)
            {
                response.IsError = true;
                response.ErrorMessage = "An error occurred. Please contact the admin.";
                return BadRequest(response);
            }
        }

    }
}
