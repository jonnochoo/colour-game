namespace api.Handlers;

public record GetTrelloCardRequest
{
    public required string CardId { get; init; }
}
