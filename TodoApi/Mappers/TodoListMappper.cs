using Microsoft.IdentityModel.Tokens;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Mappers;

public static class TodoListMappper
{
    public static OutTodoList ToOutDto(TodoList todoList)
    {
        return new OutTodoList
        {
            Id = todoList.Id,
            Name = todoList.Name,
            TodoItems = todoList.TodoItems.IsNullOrEmpty() 
                ? [] : todoList.TodoItems.Select(x => TodoItemMappper.ToOutDto(x)).ToList(),
        };
    }

    public static TodoList FromCreateDto(CreateTodoList createTodoList)
    {
        return new TodoList
        {
            Name = createTodoList.Name,
            TodoItems = []
        };
    }
}