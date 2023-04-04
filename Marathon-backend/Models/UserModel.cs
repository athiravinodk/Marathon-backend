using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Marathon_backend.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string ContactNumber { get; set; }

    }
}
