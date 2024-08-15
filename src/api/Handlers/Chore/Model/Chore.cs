public record ChoreTemplate
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required Guid PersonId { get; init; }
    public Person Person { get; init; } = null!;
    public required string Summary { get; init; }
    public required DayOfWeek[] DaysOfWeek { get; init; }
}