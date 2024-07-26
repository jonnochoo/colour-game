using Flurl.Http;
using Wolverine;

namespace api.Handlers;

public class SendNtfyHandler : IWolverineHandler
{
    public async Task Handle(SendNtfyCommand command)
    {
        string url = $"https://ntfy.sh/{command.Topic}";
        await url.PostStringAsync(command.Message);
    }
}
