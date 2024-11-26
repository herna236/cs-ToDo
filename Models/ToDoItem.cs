namespace ToDoListWebApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
