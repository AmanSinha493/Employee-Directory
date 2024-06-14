using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeDirectory.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController :ControllerBase
    {
        readonly IRoleServices _roleService;
        public LocationController(IRoleServices roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DTO.Location))]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get()
        {
            Console.WriteLine("contoller");
            var locations = _roleService.GetLocations();
            return Ok(locations);
        }
    }
}
