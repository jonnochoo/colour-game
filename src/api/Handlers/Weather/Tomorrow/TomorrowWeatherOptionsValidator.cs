namespace Api.Handlers.Weather.Tomorrow;

using FluentValidation;

public class TomorrowWeatherOptionsValidator : AbstractValidator<TomorrowWeatherOptions>
{
    public TomorrowWeatherOptionsValidator()
    {
        this.RuleFor(x => x.ApiKey).NotEmpty();
    }
}