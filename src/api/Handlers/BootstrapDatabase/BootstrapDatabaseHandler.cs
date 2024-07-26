using Microsoft.AspNetCore.Identity;

namespace api.Handlers.BootstrapDatabase;
public class BootstrapDatabaseHandler
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