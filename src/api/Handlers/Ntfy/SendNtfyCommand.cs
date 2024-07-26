namespace api.Handlers;

public record SendNtfyCommand
{
    public required string Topic { get; set; }
    public required string Message { get; set; }
};