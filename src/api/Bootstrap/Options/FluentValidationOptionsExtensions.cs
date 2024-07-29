namespace Api.Bootstrap.Options;

using FluentValidation;
using Microsoft.Extensions.Options;

public static class FluentValidationOptionsExtensions
{
    public static OptionsBuilder<TOptions> AddOptionsWithValidation<TOptions, TValidator>(
        this IServiceCollection services)
    where TOptions : class, IConfigOptions
    where TValidator : class, IValidator<TOptions>
    {
        // Add the validator
        services.AddScoped<IValidator<TOptions>, TValidator>();

        return services.AddOptions<TOptions>()
            .BindConfiguration(TOptions.SectionName)
            .ValidateFluentValidation()
            .ValidateOnStart();
    }
}