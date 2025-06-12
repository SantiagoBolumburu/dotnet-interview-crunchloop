using System.ComponentModel;
using ModelContextProtocol.Server;

namespace TodoApi.McpServer.Tools;

[McpServerToolType]
public static class TodoListsTools
{
    [McpServerTool, Description("Echos the message back to the client.")]
    public static string Echo(string message) => $"Hello from C#: {message}";


    [McpServerTool, Description("Echos in reverse the sent.")]
    public static string ReverseEcho(string message) => new string(message.Reverse().ToArray());


    [McpServerTool, Description("Returns the TodoAPI URL.")]
    public static string GetTodoApiUrl()
    {
        string todoApiUrl = Environment.GetEnvironmentVariable("TODO_API_URL") ?? "Env var not prosent";

        return todoApiUrl;
    }


    // GET: api/todolists
    // public async Task<ActionResult<IList<OutTodoList>>> GetTodoLists()

    // GET: api/todolists/5
    // public async Task<ActionResult<OutTodoList>> GetTodoList(long id)

    // PUT: api/todolists/5
    // public async Task<ActionResult> PutTodoList(long id, UpdateTodoList payload)

    // POST: api/todolists
    //public async Task<ActionResult<TodoList>> PostTodoList(CreateTodoList payload)

    // DELETE: api/todolists/5
    // public async Task<ActionResult> DeleteTodoList(long id)
}