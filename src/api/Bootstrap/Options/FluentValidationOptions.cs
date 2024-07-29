namespace Api.Bootstrap.Options;

using FluentValidation;
using Microsoft.Extensions.Options;

// From https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-using-flentvalidation/
public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class, IConfigOptions
{
    private readonly IServiceProvider serviceProvider;
    private readonly string? name;

    public FluentValidationOptions(string? name, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        // Null name is used to configure all named options.
        if (this.name != null && this.name != name)
        {
            // Ignored if not validating this instance.
            return ValidateOptionsResult.Skip;
        }

        // Ensure options are provided to validate against
        ArgumentNullException.ThrowIfNull(options);

        // Validators are registered as scoped, so need to create a scope,
        // as we will be called from the root scope
        using var scope = serviceProvider.CreateScope();
        var validator = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();
        var results = validator.Validate(options);
        if (results.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        string typeName = options.GetType().Name;
        var errors = new List<string>();
        foreach (var result in results.Errors)
        {
            errors.Add($"Fluent validation failed for '{typeName}.{result.PropertyName}' with the error: '{result.ErrorMessage}'.");
        }

        return ValidateOptionsResult.Fail(errors);
    }
}
