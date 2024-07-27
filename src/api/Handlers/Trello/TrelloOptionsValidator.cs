using FluentValidation;

namespace api.Handlers.Trello;

public class TrelloOptionsValidator : AbstractValidator<TrelloOptions>
{
    public TrelloOptionsValidator()
    {
        this.RuleFor(x => x.ApiKey).NotEmpty();
        this.RuleFor(x => x.Token).NotEmpty();
    }
}