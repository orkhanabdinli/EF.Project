namespace ConsoleApp.Task.Core.Entities;

public class GroupStudents
{
    public int GroupId { get; set; }
    public int StudentId { get; set; }
    public Group Group { get; set; } = null!;
    public Student Student { get; set; } = null!;
    public GroupStudents(int groupId, int studentId) 
    {
        GroupId = groupId;
        StudentId = studentId;
    }
}
