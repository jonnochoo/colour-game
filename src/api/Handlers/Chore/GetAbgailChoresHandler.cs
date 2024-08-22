using Microsoft.EntityFrameworkCore;

namespace Api.Handlers.Chore;

public class GetAbgailChoresHandler
{
    public async Task<ChoreTemplate[]> Handle(GetAbgailChoresRequest request, ApplicationDbContext dbContext)
    {
        var result = await dbContext.ChoreTemplates
            .Include(c => c.Person)
            .Where(c => c.PersonId == 2)
            .ToArrayAsync();

        return result;
    }
}
