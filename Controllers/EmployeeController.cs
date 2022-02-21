using Auditing.Models;
using Auditing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Auditing.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [Route("api/getEmployeeById")]
    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _employeeRepository.GetEmployeeById(employeeId);
    }

    [HttpPost]
    [Route("api/UpdateEmployeeFullName")]
    public async Task<Employee> UpdateEmployeeFullName(int employeeId,string firstName, string lastName)
    {
        var employee=await _employeeRepository.GetEmployeeById(employeeId);
        employee.UpdateFullName(firstName, lastName);
        await _employeeRepository.SaveChanges();
        return employee;
    }
}