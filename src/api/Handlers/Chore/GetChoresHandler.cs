using Microsoft.EntityFrameworkCore;

namespace Api.Handlers.Chore;

public class GetChoresHandler
{
    public async Task<ChoreTemplate[]> Handle(GetChoresRequest request, ApplicationDbContext dbContext)
    {
        var result = await dbContext.ChoreTemplates
            .Include(c => c.Person)
            .Where(c => c.PersonId == request.PersonId && c.DaysOfWeek.Contains(request.DayOfWeek))
            .ToArrayAsync(); // TODO: Map this to a DTO

        return result;
    }
}
