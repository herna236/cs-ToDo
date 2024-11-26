using Microsoft.EntityFrameworkCore;
using TodoListWebApp.Models;

namespace ToDoListWebApp.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
