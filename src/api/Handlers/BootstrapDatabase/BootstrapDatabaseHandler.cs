using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace api.Handlers.BootstrapDatabase;
public class BootstrapDatabaseHandler : IWolverineHandler
{
    public async Task Handle(BootstrapDatabaseRequest request, ApplicationDbContext dbContext, UserManager<User> userManager)
    {
        await dbContext.Database.EnsureCreatedAsync();

        User user = new User
        {
            UserName = "user"
        };
        var result = await userManager.CreateAsync(user, "Password123!");
    }
}