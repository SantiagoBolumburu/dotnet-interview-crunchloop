using System.ComponentModel;
using ModelContextProtocol.Server;
using TodoApi.McpServer.Http;

namespace TodoApi.McpServer.Tools;

[McpServerToolType]
public static class TodoItemsTools
{
    [McpServerTool, Description("Get a list with all the todo items.")]
    public static async Task<string> GetTodoItems(RequestHandler requestHandler)
    {
        var todoItemsStr = await requestHandler.GetTodoItems();

        return todoItemsStr;
    }

    [McpServerTool, Description("Get an specific todo item by it's Id.")]
    public static async Task<string> GetTodoItem(RequestHandler requestHandler,
        [Description("The id of the todo item to retrieve.")] long id)
    {
        string todoItemStr = await requestHandler.GetTodoItem(id);

        return todoItemStr;
    }

    [McpServerTool, Description("Modify the properties of a todo item.")]
    public static async Task<string> PutTodoItem(RequestHandler requestHandler,
        [Description("The id of the todo item to modify.")] long id,
        [Description("The name of the todo item to modify.")] string name,
        [Description("The description of the todo item to modify.")] string description,
        [Description("The completion status of the todo item to modify.")] bool completed)
    {
        string todoItemStr = await requestHandler.PutTodoItem(id, name, description, completed);

        return todoItemStr;
    }

    [McpServerTool, Description("Create a new todo item.")]
    public static async Task<string> PostTodoItem(RequestHandler requestHandler,
        [Description("The id of the todo list that the new todo item belongs to.")] long todoListId,
        [Description("The name of the todo item to create.")] string name,
        [Description("The description of the todo item to create.")] string description,
        [Description("The completion status of the todo item to create.")] bool completed)
    {
        string todoItemStr = await requestHandler.PostTodoItem(todoListId, name, description, completed);

        return todoItemStr;
    }

    [McpServerTool, Description("Create a new todo item.")]
    public static async Task<string> DeleteTodoItem(RequestHandler requestHandler,
        [Description("The id of the todo item to delete.")] long id)
    {
        string message = await requestHandler.DeleteTodoItem(id);

        return message;
    }
}