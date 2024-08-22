public record Person
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public ICollection<Person> People { get; } = new List<Person>();
}
