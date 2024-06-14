using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeDirectory.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController :ControllerBase
    {
        readonly IRoleServices _roleService;
        public DepartmentController(IRoleServices roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DTO.Department))]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get()
        {
            Console.WriteLine("contoller");
            var departments = _roleService.GetDepartments();
            return Ok(departments);
        }
    }
}
