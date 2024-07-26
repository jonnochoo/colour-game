using Flurl.Http;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers;

public class GetTomorrowWeatherHandler : IWolverineHandler
{
    public async Task<object> Handle(GetWeatherRequest request, IOptions<TomorrowWeatherOptions> options, ILogger<GetTomorrowWeatherHandler> logger)
    {
        string weatherApiKey = options.Value.ApiKey;
        logger.LogInformation($"Weather: {weatherApiKey}");
        string url = $"https://api.tomorrow.io/v4/weather/forecast?location={request.Longitude},{request.Latitude}&apikey={weatherApiKey}";
        var response = await url.AllowAnyHttpStatus().GetAsync();
        if (response.StatusCode != 200)
        {
            //TODO: Figure out a better to do error handling.
            throw new InvalidOperationException(response.StatusCode.ToString());
        }

        return await response.GetJsonAsync<object>();
    }
}
