using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace EmployeeDirectory.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleServices _roleService;
        public RoleController(IRoleServices roleService)
        {
            _roleService = roleService;
        }


        [HttpGet]
        [Authorize(Roles = "admin,superadmin,employee")]
        [ProducesResponseType(200, Type = typeof(DTO.Role))]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roles = _roleService.Get();
            return Ok(roles);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _roleService.Get(id);
            return Ok(employee);
        }


        [HttpPost]
        [Authorize(Roles = "superadmin")]
        public IActionResult Add([FromBody] DTO.Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _roleService.Add(role, []);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _roleService.Delete(id);
            return NoContent();
        }
    }
}
