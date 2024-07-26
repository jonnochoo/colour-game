namespace api.Handlers;

public class GetTrelloCardHandler
{
    public TrelloCard Handle(GetTrelloCardRequest command)
    {
        Console.WriteLine("I got a message!");
        return new TrelloCard() { Text = "potato" };
    }
}
