using System.ComponentModel;
using ModelContextProtocol.Server;

namespace TodoApi.McpServer.Tools;

//Made for testing mcp server

[McpServerToolType]
public static class EchoTool
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
}