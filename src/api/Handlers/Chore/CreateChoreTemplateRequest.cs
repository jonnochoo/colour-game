namespace Api.Handlers.Chore;

public record CreateChoreTemplateRequest
{
    public required int PersonId { get; init; }
    public required string Summary { get; init; }
    public required DayOfWeek[] DaysOfWeek { get; init; }
    public required TimeOfDay[] TimeOfDays { get; init; }
}
