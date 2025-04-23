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
    public class Enrollments
    {
        [Key]
        public int Enrollment_id { get; set; }

        [ForeignKey(nameof(Students))]
        public int Student_id { get; set; }

        [ForeignKey(nameof(Courses))]
        public int Course_id { get; set; }

        [ForeignKey(nameof(Semesters))]
        public int Semester_id { get; set; }

        public Students Student { get; set; }
        public Courses Course { get; set; }
        public Semesters Semester { get; set; }
    }
}