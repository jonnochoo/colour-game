using Api.Bootstrap.Options;

namespace api.Handlers.Trello;

public class TrelloOptions : IConfigOptions
{
    public static string SectionName => "Trello";

    public string ApiKey { get; set; } = null!;
    public string Token { get; set; } = null!;
}
