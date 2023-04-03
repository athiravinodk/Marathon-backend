using Microsoft.EntityFrameworkCore;

namespace Marathon_backend.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) 
        { 
        }
         public DbSet<UserDbContext> UserModel { get; set; }
    }
}
