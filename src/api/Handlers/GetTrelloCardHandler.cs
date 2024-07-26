using Wolverine;

namespace api.Handlers;

public class GetTrelloCardHandler : IWolverineHandler
{
    public TrelloCard Handle(GetTrelloCardRequest command)
    {
        Console.WriteLine("I got a message!");
        return new TrelloCard() { Text = "potato" };
    }
}
