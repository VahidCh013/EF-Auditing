using Auditing.Models;

namespace Auditing.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeById(int id);
    Task SaveChanges();
}