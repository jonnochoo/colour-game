using api.Handlers;
using Microsoft.Extensions.Caching.Memory;
using Wolverine.Http;

public class InMemoryCacheMiddleware
{
    public static IResult Before(GetTrelloCardRequest message, IMemoryCache memoryCache)
    {
        bool isInCache = memoryCache.TryGetValue("c", out object data);

        Console.WriteLine($"Before is {isInCache}");
        return Results.Unauthorized();
    }

    public static void After()
    {
        Console.WriteLine("After");
    }

    public static void Finally()
    {
        Console.WriteLine("finallys");
    }
}