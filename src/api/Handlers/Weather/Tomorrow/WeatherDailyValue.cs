namespace Api.Handlers.Weather.Tomorrow;

public record WeatherDailyValue
{
    public required double TemperatureMax { get; init; }
    public required double TemperatureMin { get; init; }
    public required double PrecipitationProbabilityAvg { get; init; }
    public required DateTimeOffset SunriseTime { get; init; }
    public required DateTimeOffset SunsetTime { get; init; }
}