using Marathon_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Marathon_backend.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions options) : base(options) 
        { 
        }
         public DbSet<UserModel> UserModels { get; set; }           // Property sets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("regform");
        }
    }
}
