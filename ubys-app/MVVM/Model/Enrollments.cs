using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ubys_app.MVVM.Model
{
    public class Enrollment
    {
        [Key]
        public int Enrollment_id { get; set; }

        [ForeignKey(nameof(Student))]
        public int Student_id { get; set; }

        [ForeignKey(nameof(Course))]
        public int Course_id { get; set; }

        [ForeignKey(nameof(Semester))]
        public int Semester_id { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
        public Semester Semester { get; set; }
    }
}