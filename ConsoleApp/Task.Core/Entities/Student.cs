using System.Collections.ObjectModel;

namespace ConsoleApp.Task.Core.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; } = 18;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Collection<GroupStudents> GroupStudents { get; set; }
}
