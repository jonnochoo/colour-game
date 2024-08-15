namespace Api.Handlers.Chore;

public record CreateChoreTemplateRequest
{
    public required Guid PersonId { get; init; }
    public required string Summary { get; init; }
    public required DayOfWeek[] DaysOfWeek { get; init; }
}
