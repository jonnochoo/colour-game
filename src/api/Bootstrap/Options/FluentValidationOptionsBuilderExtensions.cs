namespace Api.Bootstrap.Options;

using Microsoft.Extensions.Options;

public static class FluentValidationOptionsBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class, IConfigOptions
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));
        return optionsBuilder;
    }
}
