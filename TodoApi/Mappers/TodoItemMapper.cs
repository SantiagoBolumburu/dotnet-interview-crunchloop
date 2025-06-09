using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Mappers;

public static class TodoItemMappper
{
    public static OutTodoItem ToOutDto(TodoItem todoItem)
    {
        return new OutTodoItem
        {
            Id = todoItem.Id,
            TodoListId = todoItem.TodoList.Id,
            Name = todoItem.Name,
            Description = todoItem.Description,
            Completed = todoItem.Completed,
        };
    }

    public static TodoItem FromCreateDto(CreateTodoItem createTodoItem, TodoList todoList)
    {
        return new TodoItem
        {
            Name = createTodoItem.Name,
            Description = createTodoItem.Description,
            Completed = createTodoItem.Completed,
            TodoList = todoList,
        };
    }
}