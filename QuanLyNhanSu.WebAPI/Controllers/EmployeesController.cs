using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();

            var employeeViewModels = employees.Select(e => new EmployeeViewModel
            {
                Id = e.EmployeeId,
                Name = e.Name,
                Email = e.Email,
                Gender = e.Gender,
                Role = e.Role,
                Address = e.Address
            });

            return Ok(employeeViewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.EmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender,
                Role = employee.Role,
                Address = employee.Address
            };

            return Ok(employeeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] AddEmployeeViewModel addEmployeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = new Employee
            {
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                Gender = addEmployeeViewModel.Gender,
                Role = addEmployeeViewModel.Role,
                Address = addEmployeeViewModel.Address
            };
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] AddEmployeeViewModel addEmployeeViewModel)
        {
            if(!ModelState.IsValid)
    {
                return BadRequest(ModelState);
            }
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = addEmployeeViewModel.Name;
            existingEmployee.Email = addEmployeeViewModel.Email;
            existingEmployee.Gender = addEmployeeViewModel.Gender;
            existingEmployee.Role = addEmployeeViewModel.Role;
            existingEmployee.Address = addEmployeeViewModel.Address;

            await _employeeService.UpdateEmployeeAsync(existingEmployee);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
