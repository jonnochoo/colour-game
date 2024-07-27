namespace Api.Bootstrap.Validation;

using Api.Bootstrap.Validation;
using Microsoft.Extensions.Options;

public static class OptionsBuilderFluentValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));
        return optionsBuilder;
    }
}
