namespace Api.Bootstrap.Options;

public interface IConfigOptions
{
    // This idea is taken from: https://haacked.com/archive/2024/07/18/better-config-sections/
    static abstract string SectionName { get; }
}