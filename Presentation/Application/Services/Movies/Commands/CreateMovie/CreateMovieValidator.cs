using FluentValidation;

namespace Application.Services.Movies.Commands.CreateMovie;

public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Author).NotNull().NotEmpty();
    }
}
