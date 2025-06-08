namespace TodoApi.Models
{
    public class TodoList
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required List<TodoItem> TodoItems { get; set; }
    }
}