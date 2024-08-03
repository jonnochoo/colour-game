namespace api.Handlers.Trello;

public record GetMealsResponseItem
{
    public string Name { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}
