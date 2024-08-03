using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers.Trello;

public class GetMealsRequestHandler : IWolverineHandler
{
    public async Task<object> Handle(GetMealsRequest request, IOptions<TrelloOptions> trelloOptions)
    {
        string listId = "5bb567c2bcadfe0f62c15015";
        string url = $"https://api.trello.com/1/lists/{listId}/cards?key={trelloOptions.Value.ApiKey}&token={trelloOptions.Value.Token}";
        var response = await url.GetAsync();
        return await response.GetJsonAsync<GetMealsResponseItem[]>();
    }
}
