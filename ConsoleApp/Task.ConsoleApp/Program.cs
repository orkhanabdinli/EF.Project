using ConsoleApp.Task.Business.Services;
using ConsoleApp.Task.Business.Utilities.Exceptions;
using ConsoleApp.Task.Core.Entities;
using ConsoleApp.Task.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
GroupService groupService = new();
StudentService studentService = new();

TaskDbContext context = new TaskDbContext();


bool isContinue = true;
while (isContinue)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Chosse the option\n" +
                  "                   ");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1 - Create group\n" +
                      "2 - Show all groups\n" +
                      "3 - Change group name\n" +
                      "4 - Create student\n" +
                      "5 - Show all students\n" +
                      "6 - Update student info\n" +
                      "7 - Add student to group\n" +
                      "0 - Exit\n" +
                      " ");
    Console.ResetColor();

    string? option = Console.ReadLine();
    int IntOption;
    bool IsInt = int.TryParse(option, out IntOption);
    if (IsInt)
    {
        if (IntOption >= 0 && IntOption <= 6)
        {
            switch (IntOption)
            {
                case 1:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter group name:");
                        Console.ResetColor();
                        string? groupName = Console.ReadLine();
                        if (String.IsNullOrEmpty(groupName)) throw new ArgumentNullException("Name can not be null");
                        Group? dbGroup = await context.Groups.FirstOrDefaultAsync(g => g.Name == groupName);
                        if (dbGroup is not null) throw new AlreadyExistException($"{groupName} group is already exist");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter group capacity (Min 10 required):");
                        Console.ResetColor();
                        int groupCapacity = Convert.ToInt32(Console.ReadLine());
                        if (groupCapacity < 10) throw new MinRequireException("Minimum capacity is 10");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter group decription (optional):");
                        Console.ResetColor();
                        string? groupDesc = Console.ReadLine();
                        Group group = new()
                        {
                            Name = groupName,
                            Description = groupDesc,
                            MaxCapacity = groupCapacity
                        };

                        await context.Groups.AddAsync(group);
                        await context.SaveChangesAsync();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{groupName} group succsessfully added");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    break;
                case 2:
                    {
                        groupService.ShowAllGroups();
                    }
                    break;
                case 3:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        groupService.ShowAllGroups();
                        Console.Write("Enter group name:");
                        Console.ResetColor();
                        string? groupName = Console.ReadLine();
                        if (String.IsNullOrEmpty(groupName)) throw new ArgumentNullException("Name can not be null");
                        Group? dbGroup = await context.Groups.FirstOrDefaultAsync(g => g.Name == groupName);
                        if (dbGroup is null) throw new DoesNotExistException($"{groupName} group does not exist");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter new group name:");
                        Console.ResetColor();
                        string? newGroupName = Console.ReadLine();
                        if (String.IsNullOrEmpty(newGroupName)) throw new ArgumentNullException("Name can not be null");
                        if (newGroupName == groupName) throw new NewIsSameException("New group name is same as old");
                        Group? dbGroup2 = await context.Groups.FirstOrDefaultAsync(g => g.Name == newGroupName);
                        if (dbGroup2 is not null) throw new DoesNotExistException($"{groupName} group already exist");
                        dbGroup.Name = newGroupName;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    break;
                case 4:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter student name:");
                        Console.ResetColor();
                        string? studentName = Console.ReadLine();
                        if (String.IsNullOrEmpty(studentName)) throw new ArgumentNullException("Name can not be null");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter student lastname:");
                        Console.ResetColor();
                        string? studentLastName = Console.ReadLine();
                        if (String.IsNullOrEmpty(studentLastName)) throw new ArgumentNullException("Name can not be null");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter student age:");
                        Console.ResetColor();
                        int studentAge = Convert.ToInt32(Console.ReadLine());
                        if (studentAge < 16) throw new MinRequireException("You must be over 16 years old");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter student email:");
                        Console.ResetColor();
                        string? studentEmail = Console.ReadLine();
                        Student? dbStudent = await context.Students.FirstOrDefaultAsync(g => g.Email == studentEmail);
                        if (dbStudent is not null) throw new AlreadyExistException($"{studentEmail} email is already used");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter student phone:");
                        Console.ResetColor();
                        string? studentPhone = Console.ReadLine();
                        Student? dbStudent2 = await context.Students.FirstOrDefaultAsync(g => g.Phone == studentPhone);
                        if (dbStudent2 is not null) throw new AlreadyExistException($"{studentPhone} phone is already used");

                        Student student = new()
                        {
                            Name = studentName,
                            LastName = studentLastName,
                            Age = studentAge,
                            Email = studentEmail,
                            Phone = studentPhone
                        };
                        await context.Students.AddAsync(student);
                        await context.SaveChangesAsync();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Student succsessfully added");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    break;
                case 5:
                    {
                        studentService.ShowAllStudents();
                    }
                    break;
                case 6: 
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        studentService.ShowAllStudents();
                        Console.Write("Enter student Id:");
                        Console.ResetColor();
                        int? studentId = Convert.ToInt32(Console.ReadLine());
                        Student dbStudent = await context.Students.FindAsync(studentId);
                        if (dbStudent is null) throw new DoesNotExistException("Student does not exist");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter new mail:");
                        Console.ResetColor();
                        string? newMail = Console.ReadLine();
                        dbStudent.Email=newMail;
                        Student? dbStudent2 = await context.Students.FirstOrDefaultAsync(g => g.Email == newMail);
                        if (dbStudent is not null) throw new AlreadyExistException($"{newMail} email is already used");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter new phone:");
                        Console.ResetColor();
                        string? newPhone = Console.ReadLine();
                        Student? dbStudent3 = await context.Students.FirstOrDefaultAsync(g => g.Phone == newPhone);
                        if (dbStudent2 is not null) throw new AlreadyExistException($"{newPhone} phone is already used");
                        dbStudent.Phone=newPhone;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }break;
                case 7:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        studentService.ShowAllStudents();
                        Console.Write("Enter student Id:");
                        Console.ResetColor();
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Student dbStudent = await context.Students.FindAsync(studentId);
                        if (dbStudent is null) throw new DoesNotExistException("Student does not exist");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        groupService.ShowAllGroups();
                        Console.Write("Enter group Id:");
                        Console.ResetColor();
                        int groupId = Convert.ToInt32(Console.ReadLine());
                        Group? dbGroup = await context.Groups.FindAsync(groupId);
                        if (dbGroup is null) throw new DoesNotExistException("Group does not exist");
                        GroupStudents groupStudents = new()
                        {
                            GroupId = groupId,
                            StudentId = studentId
                        };
                        await context.GroupStudents.AddAsync(groupStudents);
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    break;
                case 0:
                    {
                        isContinue = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Closing App");
                    }break;

            }
        }
    }
}





