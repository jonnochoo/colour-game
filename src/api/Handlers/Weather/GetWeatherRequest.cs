namespace api.Handlers;

public record GetWeatherRequest
{
    public required string Longitude { get; set; }
    public required string Latitude { get; set; }

    public static GetWeatherRequest BaulkhamHills()
    {
        return new GetWeatherRequest { Longitude = "-33.760672", Latitude = "150.993018" };
    }
}
