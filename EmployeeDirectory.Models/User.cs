using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models
{
    public class User
    {
        [Key]
        public string user { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
