namespace TodoApi.Dtos;

public class CreateTodoItem
{
    public required long TodoListId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
}
