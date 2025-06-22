using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Entities.Models
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public User? Professor { get; set; }
        public int? ProfessorId { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}
