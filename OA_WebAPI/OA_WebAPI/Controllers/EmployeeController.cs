using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_DataAccess;
using OA_Service;

namespace OA_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Field
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Methods

        [Route("GetAllEmployee")]
        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeParameters employeeParameters)
        {
            var employees = _employeeService.GetAllEmployee(employeeParameters);
            return Ok(employees);
        }

        [Route("EmployeedetailById")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Employee employee = _employeeService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(employee);
        }

        [Route("AddOrUpdateEmployee")]
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            if (employee.Id == 0)
            {
                _employeeService.AddEmployee(employee);
            }
            else
            {
                Employee employeeToUpdate = _employeeService.GetEmployee(employee.Id);
                if (employeeToUpdate == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }

                _employeeService.UpdateEmployee(employee);
            }

            return Ok("data save");
        }

        [Route("DeleteEmployee")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _employeeService.DeleteEmployee(employee);
            return Ok("delete successfully");
        }

        #endregion

    }
}
