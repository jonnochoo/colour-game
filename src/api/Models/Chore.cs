public record Chore
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
}