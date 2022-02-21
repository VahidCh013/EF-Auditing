namespace Auditing.Models;

public interface IAudit
{
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}