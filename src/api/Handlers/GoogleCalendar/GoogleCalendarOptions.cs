namespace api.Handlers.GoogleCalendar;

public record GoogleCalendarOptions
{
    public const string ConfigName = "GoogleCalendar";
    public required string PrivateKey { get; init; }
    public required string ServiceEmailAccount { get; init; }
}
