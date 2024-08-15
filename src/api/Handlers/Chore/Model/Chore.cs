public record ChoreTemplate
{
    public Guid Id { get; set; }

    public required Guid PersonId { get; init; }
    public required Person Person { get; init; }

    public required string Description { get; init; }

    public required DayOfWeek[] DaysOfWeek { get; init; }
}