namespace api.Handlers.Trello;

public record GetMealsResponseItem
{
    public required string Name { get; init; }
    public required DayOfWeek DayOfWeek { get; init; }
}
