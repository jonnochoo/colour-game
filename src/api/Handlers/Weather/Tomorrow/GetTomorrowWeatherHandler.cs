namespace Api.Handlers.Weather.Tomorrow;

using api.Handlers;
using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;


public class GetTomorrowWeatherHandler : IWolverineHandler
{
    public async Task<object> Handle(GetWeatherRequest request, IOptions<TomorrowWeatherOptions> options, ILogger<GetTomorrowWeatherHandler> logger, IMemoryCache memoryCache)
    {
        string weatherApiKey = options.Value.ApiKey;
        string url = $"https://api.tomorrow.io/v4/weather/forecast?location={request.Longitude},{request.Latitude}&apikey={weatherApiKey}";
        var response = await url.AllowAnyHttpStatus().GetAsync();
        if (response.StatusCode != 200)
        {
            //TODO: Figure out a better to do error handling.
            throw new InvalidOperationException(response.StatusCode.ToString());
        }

        var tomorrowWeatherResponse = await response.GetJsonAsync<TomorrowWeatherResponse>();
        var currentInfo = tomorrowWeatherResponse.Timelines.Minutely[0].Values;
        var todayInfo = tomorrowWeatherResponse.Timelines.Daily[0].Values;
        var tomorrowInfo = tomorrowWeatherResponse.Timelines.Daily[1].Values;
        var inTwoDaysInfo = tomorrowWeatherResponse.Timelines.Daily[2].Values;

        return new GetTomorrowWeatherResponse
        {
            WeatherCode = currentInfo.WeatherCode,
            TemperatureCurrent = currentInfo.Temperature,
            WindspeedCurrent = currentInfo.WindSpeed,
            HumidityCurrent = currentInfo.Humidity,
            UVIndex = currentInfo.UVIndex,
            Today = todayInfo,
            Tomorrow = tomorrowInfo,
            InTwoDays = inTwoDaysInfo,
        };
    }
}

// See .Sample/tomorrow.json for the payload
// https://docs.tomorrow.io/reference/data-layers-core
internal record TomorrowWeatherResponse
{
    public required Timelines Timelines { get; init; }
}

internal record Timelines
{
    public required WeatherMinute[] Minutely { get; init; } = [];
    public required WeatherDaily[] Daily { get; init; } = [];
}

internal record WeatherMinute
{
    public required DateTimeOffset Time { get; init; }
    public required WeatherMinuteValue Values { get; init; }
}

internal record WeatherDaily
{
    public required DateTimeOffset Time { get; init; }
    public required WeatherDailyValue Values { get; init; }
}

internal record WeatherMinuteValue
{
    public required double Humidity { get; init; }
    public required double Temperature { get; init; }
    public required double PrecipitationProbability { get; init; }
    public required int WeatherCode { get; init; }
    public required double WindSpeed { get; init; }
    public required int UVIndex { get; init; }
}
