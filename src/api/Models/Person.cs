public record Person
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public ICollection<Person> People { get; } = new List<Person>();
}