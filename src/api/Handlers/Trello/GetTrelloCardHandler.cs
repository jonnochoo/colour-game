using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers.Trello;

public class GetTrelloCardHandler : IWolverineHandler
{
    public async Task<object> Handle(GetTrelloCardRequest request, IOptions<TrelloOptions> trelloOptions, IMemoryCache memoryCache)
    {
        const string trelloCacheKey = "weather";
        object trelloData = null!;
        if (!memoryCache.TryGetValue(trelloCacheKey, out trelloData))
        {
            string url = $"https://api.trello.com/1/cards/{request.CardId}?key={trelloOptions.Value.ApiKey}&token={trelloOptions.Value.Token}";
            var response = await url.GetAsync();
            trelloData = await response.GetJsonAsync<object>();

            memoryCache.Set(trelloCacheKey, trelloData, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10)));
        }

        return trelloData;
    }
}
