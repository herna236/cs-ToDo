using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoContext _context;

        public IndexModel(ToDoContext context)
        {
            _context = context;
            TodoItems = new List<TodoItem>();  // Initialize the TodoItems property to an empty list
        }

        public IList<TodoItem> TodoItems { get; set; }

        // Handle GET request for the page to display all items
        public async Task OnGetAsync()
        {
            TodoItems = await _context.TodoItems.ToListAsync();
        }

       
        public async Task<IActionResult> OnPostAsync(string title, string description, DateTime dueDate, int priority)
        {
            var todoItem = new TodoItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                IsCompleted = false
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        // Handle POST request to mark a ToDo item as completed
        public async Task<IActionResult> OnPostCompleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                todoItem.IsCompleted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        // Handle POST request to delete a ToDo item
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
