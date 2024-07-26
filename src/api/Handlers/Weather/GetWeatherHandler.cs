using Flurl.Http;
using Wolverine;

namespace api.Handlers;

public class GetWeatherHandler : IWolverineHandler
{
    public async Task<object> Handle(GetWeatherRequest request)
    {
        string weatherApiKey = "";
        string url = $"https://api.tomorrow.io/v4/weather/forecast?location={request.Longitude},{request.Latitude}&apikey={weatherApiKey}";
        var response = await url.AllowAnyHttpStatus().GetAsync();
        if (response.StatusCode != 200)
        {
            //TODO: Figure out a better to do error handling.
            throw new InvalidOperationException(response.StatusCode.ToString());
        }

        return response;
    }
}

public record WeatherResponse
{

}
