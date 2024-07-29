using Api.Bootstrap.Options;
using FluentValidation;

namespace api.Handlers.GoogleCalendar;

public record GoogleCalendarOptions : IConfigOptions
{
    public static string SectionName => "GoogleCalendar";
    public required string PrivateKey { get; init; }
    public required string ServiceEmailAccount { get; init; }
}

public class GoogleCalendarOptionsValidator : AbstractValidator<GoogleCalendarOptions>
{
    public GoogleCalendarOptionsValidator()
    {
        this.RuleFor(x => x.PrivateKey).NotEmpty();
        this.RuleFor(x => x.ServiceEmailAccount).NotEmpty();
    }
}