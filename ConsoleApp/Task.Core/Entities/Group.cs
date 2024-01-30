using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Task.Core.Entities;
public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int MaxCapacity { get; set; } 
    public int? CurrentStudentCount { get; set; }
    public Collection<GroupStudents> GroupStudents { get; set; }
}
