using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Semesters
    {
        [Key]
        public int Semester_id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
    }
}
