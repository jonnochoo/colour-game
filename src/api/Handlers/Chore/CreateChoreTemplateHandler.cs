namespace Api.Handlers.Chore;

public class CreateChoreTemplateHandler
{
    public async Task Handle(CreateChoreTemplateRequest request, ApplicationDbContext dbContext)
    {
        Console.WriteLine("asdf");

        // Check if the person id exist
        var result = await dbContext.ChoreTemplates.AddAsync(new ChoreTemplate
        {
            PersonId = request.PersonId,
            Summary = request.Summary,
            DaysOfWeek = request.DaysOfWeek
        });

        await dbContext.SaveChangesAsync();
    }
}