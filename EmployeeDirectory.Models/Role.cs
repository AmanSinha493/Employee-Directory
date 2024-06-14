using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models
{
    public class Role
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public string? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
