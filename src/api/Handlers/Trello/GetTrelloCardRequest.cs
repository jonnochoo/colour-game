namespace api.Handlers;

public record GetTrelloCardRequest
{
    public required string CardId { get; init; }

    public static GetTrelloCardRequest ForAbigail()
    {
        return new GetTrelloCardRequest { CardId = "6698f15b08496fa1b211f617" };
    }
    public static GetTrelloCardRequest ForElijah()
    {
        return new GetTrelloCardRequest { CardId = "6698f157ecbacd29624830dc" };
    }
}
