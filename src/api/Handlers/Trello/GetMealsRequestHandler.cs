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
        Console.WriteLine("HUHasdasdf");
        var item12s = await response.GetStringAsync();
        Console.WriteLine("HUH", item12s);
        var items = await response.GetJsonAsync<GetMealsResponseItem[]>();
        var newItems = items
            .Where(x => x != null && x.Name.Split(":").Length == 2)
            .Select(x =>
            {
                var splitText = x.Name.Split(":");
                return x with
                {
                    Name = splitText[1],
                    DayOfWeek = GetDateOfWeek(splitText[0])
                };
            });

        return newItems.ToArray();
    }

    private static DayOfWeek GetDateOfWeek(string text)
    {
        Console.WriteLine(text);

        text = text.ToLower().Trim();
        return text switch
        {
            "mon" or "monday" => DayOfWeek.Monday,
            "tue" or "tuesday" => DayOfWeek.Tuesday,
            "wed" or "wednesday" => DayOfWeek.Wednesday,
            "thu" or "thursday" => DayOfWeek.Thursday,
            "fri" or "friday" => DayOfWeek.Friday,
            "sat" or "saturday" => DayOfWeek.Saturday,
            "sun" or "sunday" => DayOfWeek.Sunday,
            _ => throw new InvalidOperationException($"Unable to find value for: {text}")
        };
    }
}
