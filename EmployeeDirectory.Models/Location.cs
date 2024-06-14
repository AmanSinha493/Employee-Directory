using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models
{
    public class Location
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Role>? Roles { get; set; }
    }
}
