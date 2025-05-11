using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ubys_app.MVVM.Model
{
    [Index(nameof(LoginNumber), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

       

        [Required]

        public int LoginNumber { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        Student = 0,
        Teacher = 1,
        Admin = 2
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}