using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DTO
{
    public class Role
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public Department department { get; set; }
        public Location location { get; set; }
        public string? Description { get; set; }
    }
}
