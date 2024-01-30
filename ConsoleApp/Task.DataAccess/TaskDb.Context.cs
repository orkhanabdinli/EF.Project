using ConsoleApp.Task.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Task.DataAccess;

public class TaskDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TaskGroup;Trusted_Connection=True;Encrypt=false");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupStudents>()
            .HasKey(gs => new { gs.StudentId, gs.GroupId });

        modelBuilder.Entity<Group>()
            .Ignore(x => x.CurrentStudentCount);

        modelBuilder.Entity<Group>()
            .HasIndex(x => x.Name)
            .IsUnique();

        modelBuilder.Entity<Group>()
            .HasMany(g => g.GroupStudents)
            .WithOne(gs => gs.Group)
            .HasForeignKey(gs => gs.GroupId);
        
        modelBuilder.Entity<Student>()
            .HasIndex(x => x.Email)
            .IsUnique();
        
        modelBuilder.Entity<Student>()
            .HasIndex(x => x.Phone)
            .IsUnique();

        modelBuilder.Entity<Student>()
            .HasMany(g => g.GroupStudents)
            .WithOne(gs => gs.Student)
            .HasForeignKey(gs => gs.StudentId);
    }
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<GroupStudents> GroupStudents { get; set; } = null!;
}


