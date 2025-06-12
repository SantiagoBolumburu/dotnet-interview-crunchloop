using System.ComponentModel;
using ModelContextProtocol.Server;
using TodoApi.McpServer.Http;

namespace TodoApi.McpServer.Tools;

[McpServerToolType]
public static class TodoListsTools
{
    [McpServerTool, Description("Get a list of all the todo lists.")]
    public static async Task<string> GetTodoLists(RequestHandler requestHandler)
    {
        var todoListsStr = await requestHandler.GetTodoLists();

        return todoListsStr;
    }

    [McpServerTool, Description("Get an specific todo list by it's Id.")]
    public static async Task<string> GetTodoList(RequestHandler requestHandler,
        [Description("The id of the todo list to retrieve.")] long id)
    {
        string todoListStr = await requestHandler.GetTodoLists(id);

        return todoListStr;
    }

    [McpServerTool, Description("Modify the properties of a todo list.")]
    public static async Task<string> PutTodoList(RequestHandler requestHandler,
        [Description("The id of the todo list to modify.")] long id,
        [Description("The name of the todo list to modify.")] string name)
    {
        string todoListStr = await requestHandler.PutTodoList(id, name);

        return todoListStr;
    }

    [McpServerTool, Description("Create a new todo list.")]
    public static async Task<string> PostTodoList(RequestHandler requestHandler,
        [Description("The name of the todo list to create.")] string name)
    {
        string todoListStr = await requestHandler.PostTodoList(name);

        return todoListStr;
    }

    [McpServerTool, Description("Create a new todo list.")]
    public static async Task<string> DeleteTodoList(RequestHandler requestHandler,
        [Description("The id of the todo list to delete.")] long id)
    {
        string message = await requestHandler.DeleteTodoList(id);

        return message;
    }
}