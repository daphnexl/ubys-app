using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Roles
    {

        [Key]
        public int Role_id { get; set; }

        [Required]
        public string Role_name { get; set; }
    }
}
