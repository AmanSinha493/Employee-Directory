using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeDirectory.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        readonly IEmployeeServices _empService;
        public ProjectController(IEmployeeServices empService)
        {
            _empService = empService;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DTO.Project))]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get()
        {
            Console.WriteLine("contoller");
            var Projects = _empService.GetProjects();
            return Ok(Projects);
        }
    }
}


