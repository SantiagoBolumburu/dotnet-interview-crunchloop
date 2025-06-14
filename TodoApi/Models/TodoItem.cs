namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
    public required TodoList TodoList { get; set; }
}
