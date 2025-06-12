using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoApi.McpServer.Http;

public class RequestHandler
{
    private readonly string _missingUrlMessage = "{ \"message\" : \"The TodoApi URL envirenmente variable is not present, or is empty.\"}";
    private readonly HttpClient _httpClient;
    private readonly string _todoApiUrl;
    private readonly string _todoApiItemsUrl;
    private readonly string _todoApiListsUrl;
    private readonly bool _todoApiUrlMissing;

    public RequestHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _todoApiUrl = Environment.GetEnvironmentVariable("TODO_API_URL") ?? "";
        _todoApiItemsUrl = _todoApiUrl + "/api/todoitems";
        _todoApiListsUrl = _todoApiUrl + "/api/todolists";;
        _missingUrlMessage = _missingUrlMessage + "(" + _todoApiUrl + ")";
        _todoApiUrlMissing = string.IsNullOrEmpty(_todoApiUrl);
    }

    private async Task<string> GetResponseContentAsStringOrDefault(string defaultStr, HttpResponseMessage response)
    {
        string responseContentString = defaultStr;
        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(responseContent))
            {
                responseContentString = responseContent;
            }
        }

        return responseContentString;
    }

    // GET: api/todoitems
    //public async Task<ActionResult<IList<OutTodoItem>>> GetTodoItem()
    public async Task<string> GetTodoItems()
    {
        if (_todoApiUrlMissing) { return _missingUrlMessage; }

        var response = await _httpClient.GetAsync(_todoApiItemsUrl);

        string items = await GetResponseContentAsStringOrDefault("[]", response);

        return items;
    }

    // GET: api/todoitems/5
    // public async Task<ActionResult<OutTodoItem>> GetTodoItem(long id)
    public async Task<string> GetTodoItem(long id)
    {
        if (_todoApiUrlMissing) { return _missingUrlMessage; }

        string url = _todoApiItemsUrl + "/" + id;
        var response = await _httpClient.GetAsync(url);

        string item = await GetResponseContentAsStringOrDefault("{}", response);

        return item;
    }

    // PUT: api/todoitems/5
    // public async Task<ActionResult> PutTodoItem(long id, UpdateTodoItem payload)
    public async Task<string> PutTodoItem(long id, string name, string description, bool completed)
    {
        if (_todoApiUrlMissing) { return _missingUrlMessage; }

        string url = _todoApiItemsUrl + "/" + id;

        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                Name = name,
                Description = description,
                Completed = completed,
            }
            ),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PutAsync(url, jsonContent);

        string item = await GetResponseContentAsStringOrDefault("{}", response);

        return item;
    }

    // POST: api/todoitems
    // public async Task<ActionResult<OutTodoItem>> PostTodoItem(CreateTodoItem payload)
    public async Task<string> PostTodoItem(long todoListId, string name, string description, bool completed)
    {
        if (_todoApiUrlMissing) { return _missingUrlMessage; }

        string url = _todoApiItemsUrl;

        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                TodoListId = todoListId,
                Name = name,
                Description = description,
                Completed = completed,
            }
            ),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync(url, jsonContent);

        string item = await GetResponseContentAsStringOrDefault("{}", response);

        return item;
    }
    
    // DELETE: api/todoitems/5
    // public async Task<ActionResult> DeleteTodoItem(long id)
    public async Task<string> DeleteTodoItem(long id)
    {
        if (_todoApiUrlMissing) { return _missingUrlMessage; }

        string url = _todoApiItemsUrl + "/" + id;

        var response = await _httpClient.DeleteAsync(url);

        string responseStr;
        if (response.IsSuccessStatusCode)
        {
            responseStr = "{ \"message\" : \"Todo item removed succesfully\"}";
        }
        else {
            responseStr = "{ \"message\" : \"Somthing happend, the todo item was not removed\"}";
        }

        return responseStr;
    }
}