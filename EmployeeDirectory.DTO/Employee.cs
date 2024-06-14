using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DTO
{
    public class Employee
    {
        //[Required(ErrorMessage = "ID is required")]
        //[RegularExpression(@"^TZ\d{4}$", ErrorMessage = "ID should be in format TZ0000")]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        //[RegularExpression("^[a-zA-Z\\s]*$\r\n", ErrorMessage = "Name must contain only letters")]
        public string? Name { get; set; }
        public string? ProfileImage { get; set; }

        //[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last Name must contain only letters")]
        //public string? LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Joining date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public string? JoiningDate { get; set; }

        public Department Department { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        public string? Role { get; set; }
        public string? RoleID { get; set; }

        [Required(ErrorMessage = "Location ID is required")]

        public Location location { get; set; }
        public string? Status { get; set; }


        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid mobile number")]
        public string? MobileNo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public string? Dob { get; set; }

        public string? Manager { get; set; }
        public Project Project { get; set; }

    }
}
