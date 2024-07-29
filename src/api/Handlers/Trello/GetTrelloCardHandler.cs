using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers.Trello;

public class GetTrelloCardHandler : IWolverineHandler
{
    public async Task<object> Handle(GetTrelloCardRequest request, IOptions<TrelloOptions> trelloOptions)
    {
        string url = $"https://api.trello.com/1/cards/{request.CardId}?key={trelloOptions.Value.ApiKey}&token={trelloOptions.Value.Token}";
        var response = await url.GetAsync();
        return await response.GetJsonAsync<object>();
    }
}
