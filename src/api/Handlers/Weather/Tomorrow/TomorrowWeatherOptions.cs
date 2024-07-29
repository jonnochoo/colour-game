using Api.Bootstrap.Options;

namespace Api.Handlers.Weather.Tomorrow;
public class TomorrowWeatherOptions : IConfigOptions
{
    public static string SectionName => "TomorrowWeather";

    public string ApiKey { get; set; } = null!;
}
