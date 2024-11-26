namespace ToDoListWebApp.Models
{
  public class TodoItem
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
}
}
