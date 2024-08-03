using System;
using System.Linq;
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
        var items = await response.GetJsonAsync<GetMealsResponseItem[]>();
        var newItems = items
            .Where(x => x != null && x.Name.Split(":").Length == 2)
            .Select(x =>
            {
                var splitText = x.Name.Split(":");
                x.Name = splitText[1];
                x.DayOfWeek = GetDateOfWeek(splitText[0]);
                return x;
            });

        return newItems.ToArray();
    }

    private static DayOfWeek GetDateOfWeek(string text)
    {

        text = text.ToLower().Trim();
        return text switch
        {
            "mon" or "monday" => DayOfWeek.Monday,
            "tue" or "tuesday" => DayOfWeek.Tuesday,
            "wed" or "wednesday" => DayOfWeek.Wednesday,
            "thu" or "thursday" => DayOfWeek.Tuesday,
            "fri" or "friday" => DayOfWeek.Friday,
            "sat" or "saturday" => DayOfWeek.Saturday,
            "sun" or "sunday" => DayOfWeek.Sunday,
            _ => throw new InvalidOperationException($"Unable to find value for: {text}")
        };
    }
}
