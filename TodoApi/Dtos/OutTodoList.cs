namespace TodoApi.Dtos;

public class OutTodoList
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required List<OutTodoItem> TodoItems { get; set; }
}
