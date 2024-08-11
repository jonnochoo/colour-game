using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers.Trello;

public class GetTodoListHandler : IWolverineHandler
{
    public async Task<object> Handle(GetTodoListRequest request, IOptions<TrelloOptions> trelloOptions)
    {
        string listId = "669a4de4d39ad7dcdd79e15b";
        string url = $"https://api.trello.com/1/lists/{listId}/cards?key={trelloOptions.Value.ApiKey}&token={trelloOptions.Value.Token}";
        var response = await url.GetAsync();
        return await response.GetJsonAsync<GetTodoListResponseItem[]>();
    }
}

public record GetTodoListResponseItem
{
    public required string Name { get; init; }
}