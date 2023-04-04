using Microsoft.EntityFrameworkCore;
using ToDoList_ToDoAPI.Models;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ToDo>().HasData(
        //        new ToDo() //If you forget to add something and need to amend the migration, simply
        //                   //do the same add-migration>update-database process, but give the migration
        //                   //a new name; ef core is able to make everything work that way
        //        {
        //            Id = 1,
        //            Title = "First To Do",
        //            Note = "Make a first to do task",
        //            IsComplete = true,
        //            DeadlineDateTime = new DateTime(2023, 3, 30, 12, 0, 0, DateTimeKind.Local),
        //            CreatedDate = new DateTime(2023, 3, 30, 11, 0, 0, DateTimeKind.Local)
        //        },
        //        new ToDo()
        //        {
        //            Id = 2,
        //            Title = "Second To Do",
        //            Note = "Make a second to do task",
        //            IsComplete = true,
        //            DeadlineDateTime = new DateTime(2023, 3, 30, 13, 0, 0, DateTimeKind.Local),
        //            CreatedDate = new DateTime(2023, 3, 30, 11, 0, 0, DateTimeKind.Local)
        //        });
        //}
    }
}
