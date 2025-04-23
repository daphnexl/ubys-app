using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Teachers
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int Teacher_id { get; set; }

        [Required]
        public string Department { get; set; }

        public User User { get; set; }
    }
}