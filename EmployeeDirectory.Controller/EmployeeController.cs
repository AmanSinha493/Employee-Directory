using EmployeeDirectory.DTO;
using EmployeeDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class EmployeesController : ControllerBase
    {
        readonly IEmployeeServices _empService;
        public EmployeesController(IEmployeeServices empService)
        {
            _empService = empService;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DTO.Employee))]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get()
        {
            Console.WriteLine("contoller");
            var Employees = _empService.Get();
            return Ok(Employees);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "admin,superadmin,employee")]
        public IActionResult Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _empService.Get(id);
            return Ok(employee);
        }


        [HttpPost]
        [Authorize(Roles = "superadmin")]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _empService.Add(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,superadmin")]
        public IActionResult Update([FromBody] Employee employee, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _empService.Edit(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin")]
        public IActionResult Delete(string id)
        {
            _empService.Delete(id);
            return NoContent();
        }
    }
}
