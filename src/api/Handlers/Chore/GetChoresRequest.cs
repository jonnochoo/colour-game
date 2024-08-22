namespace Api.Handlers.Chore;

public record GetChoresRequest
{
    public int PersonId { get; set; }
    public DayOfWeek DayOfWeek { get; set; } = DateTimeOffset.Now.DayOfWeek;

    public static GetChoresRequest Abigail(DayOfWeek? dayOfWeek)
    {
        if (dayOfWeek == null)
        {
            return new GetChoresRequest { PersonId = PersonIds.Abigail };
        }

        return new GetChoresRequest { PersonId = PersonIds.Abigail, DayOfWeek = dayOfWeek.Value };
    }

    public static GetChoresRequest Elijah(DayOfWeek? dayOfWeek)
    {
        if (dayOfWeek == null)
        {
            return new GetChoresRequest { PersonId = PersonIds.Elijah };
        }

        return new GetChoresRequest { PersonId = PersonIds.Elijah, DayOfWeek = dayOfWeek.Value };
    }
}