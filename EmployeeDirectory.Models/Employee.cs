using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models
{
    public class Employee
    {
        [Key]
        public string? Id { get; set; }
        public string? ProfileImage { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public string? MobileNo { get; set; }
        public string? JoiningDate { get; set; }
        public string? Status { get; set; }
        public string? Dob { get; set; }
        public string? Manager { get; set; }
        public string? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
