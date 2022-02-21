using Auditing.Models;

namespace Auditing.Repositories;

public class EmployeeRepository:IEmployeeRepository
{
    private readonly EmployeeDbContext _employeeDbContext;

    public EmployeeRepository(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _employeeDbContext.Employees.FindAsync(id);
        
    }

    public async Task SaveChanges()
    {
        await _employeeDbContext.SaveChangesAsync();
    }
}