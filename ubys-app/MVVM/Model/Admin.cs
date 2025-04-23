using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.MVVM.Model
{
    public class Admin
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int Admin_id { get; set; }

        public User User { get; set; }
    }
}