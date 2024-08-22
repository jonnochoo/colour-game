namespace Api.Handlers.Chore;

public class CreateChoreTemplateHandler
{
    public async Task<Guid> Handle(CreateChoreTemplateRequest request, ApplicationDbContext dbContext)
    {
        // TODO: Check if the person id exist

        var result = await dbContext.ChoreTemplates.AddAsync(new ChoreTemplate
        {
            PersonId = request.PersonId,
            Summary = request.Summary,
            DaysOfWeek = request.DaysOfWeek,
            TimeOfDays = request.TimeOfDays
        });

        await dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }
}
