using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Courses
    {
        [Key]
        public int Course_id { get; set; }

        [Required]
        public string Course_code { get; set; }

        [Required]
        public string Course_name { get; set; }

        public int Credits { get; set; }

        public int Teacher_id { get; set; }


        [ForeignKey("Teacher_id")]
        public Teachers Teacher { get; set; }
    }
}
