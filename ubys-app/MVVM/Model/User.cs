using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
        [ForeignKey(nameof(Roles))]
        public int Role { get; set; }

        [Required]

        public int LoginNumber { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public Roles RoleNavigation { get; set; }

    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}