using Azure;
using ConsoleApp.Task.Business.Interfaces;
using ConsoleApp.Task.Business.Utilities.Exceptions;
using ConsoleApp.Task.Core.Entities;
using ConsoleApp.Task.DataAccess;
using System.Numerics;

namespace ConsoleApp.Task.Business.Services;

public class StudentService : IStudenService
{
    TaskDbContext context = new ();
    //public void Create(string name, string lastName, int age, string email, string phone)
    //{
    //    if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("Name can not be null");
    //    if (String.IsNullOrEmpty(lastName)) throw new ArgumentNullException("Lasname can not be null");
    //    if (age < 16) throw new MinRequireException("You must be over 16 years old");
    //    Student? dbStudent = context.Students.Find(email);
    //    if (dbStudent is not null) throw new AlreadyExistException($"{email} email is already exist");
    //    Student? dbStudent2 = context.Students.Find(email);
    //    if (dbStudent2 is not null) throw new AlreadyExistException($"{phone} phone is already exist");

    //    Student student = new()
    //    {
    //        Name = name,
    //        LastName = lastName,
    //        Age = age,
    //        Email = email,
    //        Phone = phone
    //    };
    //    await context.Students.AddAsync(student);
    //    await context.SaveChangesAsync();
    //}
    //public void AddToGroup(int studentId, int groupId)
    //{
    //    Student? dbStudent = context.Students.Find(studentId);
    //    if (dbStudent is null) throw new DoesNotExistException("Student does not exist");
    //    if (dbStudent.)
    //        Group? dbGroup = context.Groups.Find(groupId);
    //    if (dbGroup is null) throw new DoesNotExistException("Group does not exist");
    //    GroupStudents groupStudents = new(groupId, studentId);
    //    context.GroupStudents.Add(groupStudents);
    //}
    public void ShowAllStudents()
    {
        foreach (var item in context.Students) 
        {
            Console.WriteLine($"Id: {item.Id} Name/Lastname: {item.Name} {item.LastName} Age: {item.Age}\n"+
                              $"Email: {item.Email} Phone: {item.Phone}");
        }
    }
}
