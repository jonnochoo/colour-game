namespace api.Handlers.Trello;

public class TrelloOptions
{
    public const string ConfigName = "Trello";

    public string ApiKey { get; set; } = null!;
    public string Token { get; set; } = null!;
}
