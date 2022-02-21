namespace Auditing.Models;

public class Employee:IAudit
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }



    public void UpdateFullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}