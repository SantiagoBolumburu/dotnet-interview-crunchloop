namespace TodoApi.Dtos;

public class UpdateTodoItem
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
}
