namespace api.Handlers.Trello;

public record GetMealsResponseItem
{
    public required string Name { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
}
