using ConsoleApp.Task.Business.Interfaces;
using ConsoleApp.Task.Business.Utilities.Exceptions;
using ConsoleApp.Task.Core.Entities;
using ConsoleApp.Task.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Task.Business.Services;

public class GroupService : IGroupService
{
    TaskDbContext context = new();
    //public async void Create(string name, string description, int maxCapacity)
    //{
    //    if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("Name can not be null");
    //    Group? dbGroup = await context.Groups.FirstOrDefaultAsync(g => g.Name == name);
    //    if (dbGroup is not null) throw new AlreadyExistException($"{name} group is already exist");
    //    if (maxCapacity < 10) throw new MinRequireException("Minimum capacity is 10");
    //    Group group = new()
    //    {
    //        Name = name,
    //        Description = description,
    //        MaxCapacity = maxCapacity
    //    };

    //    await context.Groups.AddAsync(group);
    //    await context.SaveChangesAsync();
       
    //}
    public void ShowAllGroups()
    {
        foreach (var item in context.Groups)
        {
            Console.WriteLine($"Id: {item.Id}  Name:{item.Name}  Description: {item.Description}");
        }
    }
   
}
