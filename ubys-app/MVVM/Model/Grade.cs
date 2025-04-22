using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Grade
    {
        [Key]
        public int Grade_id { get; set; }

        [Required]
        [ForeignKey(nameof(Enrollment))]
        public int Enrollment_id { get; set; }

        public double? Midterm_grade { get; set; }
        public double? Final_grade { get; set; }
        public string? Letter_grade { get; set; }

        public Enrollment Enrollment { get; set; }
    }
}
