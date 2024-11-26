using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
