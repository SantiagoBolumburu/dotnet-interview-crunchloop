namespace TodoApi.Dtos;

public class OutTodoItem
{
    public required long Id { get; set; }
    public required long TodoListId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
}
