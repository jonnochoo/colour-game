using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers;

public class GetTomorrowWeatherHandler : IWolverineHandler
{
    public async Task<object> Handle(GetWeatherRequest request, IOptions<TomorrowWeatherOptions> options, ILogger<GetTomorrowWeatherHandler> logger, IMemoryCache memoryCache)
    {
        object weatherResponse = null!;
        if (!memoryCache.TryGetValue("weather", out weatherResponse))
        {
            string weatherApiKey = options.Value.ApiKey;
            string url = $"https://api.tomorrow.io/v4/weather/forecast?location={request.Longitude},{request.Latitude}&apikey={weatherApiKey}";
            var response = await url.AllowAnyHttpStatus().GetAsync();
            if (response.StatusCode != 200)
            {
                //TODO: Figure out a better to do error handling.
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
            weatherResponse = await response.GetJsonAsync<object>();
            memoryCache.Set("weather", weatherResponse, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10)));
            logger.LogInformation($"Retrieved from API!");

            return weatherResponse;
        }

        logger.LogInformation($"Retrieved from cache!");

        return weatherResponse;
    }
}