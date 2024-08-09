using Api.Handlers.Weather.Tomorrow;

namespace api.Handlers;

public record GetTomorrowWeatherResponse
{
    public required double HumidityCurrent { get; init; }
    public required double TemperatureCurrent { get; init; }
    public required int UVIndex { get; init; }
    public string UVIndexConcern
    {
        get
        {
            return this.UVIndex switch
            {
                >= 0 and <= 2 => "Low",
                >= 3 and <= 5 => "Moderate",
                >= 6 and <= 7 => "High",
                >= 8 and <= 10 => "Very High",
                >= 11 => "Extreme",
                _ => "Invalid value" // Handle negative or unexpected inputs
            };
        }
    }
    public required double WindspeedCurrent { get; init; }
    public required int WeatherCode { get; init; }
    public required WeatherDailyValue Today { get; init; }
    public required WeatherDailyValue Tomorrow { get; init; }
    public required WeatherDailyValue InTwoDays { get; init; }
}
