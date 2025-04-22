using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{

    public class Student
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int Student_id { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public int Grade { get; set; }

        public User User { get; set; }
    }
}
