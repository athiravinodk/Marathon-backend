using Marathon_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Marathon_backend.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> UserModels { get; set; }

        //protected readonly IConfiguration Configuration;

        //public UserDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

    }
}
