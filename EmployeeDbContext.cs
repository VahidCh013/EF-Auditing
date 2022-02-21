using Auditing.Models;
using Microsoft.EntityFrameworkCore;

namespace Auditing;

public class EmployeeDbContext:DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
    {
        
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleTracker();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void HandleTracker()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.Entity is IAudit
                && e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach (var entityEntry in entities)
        {
            var entity = (IAudit)entityEntry.Entity;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedOn=DateTime.Now;
                    entity.ModifiedOn=DateTime.Now;
                    break;
                case EntityState.Modified:
                    entity.ModifiedOn=DateTime.Now;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}