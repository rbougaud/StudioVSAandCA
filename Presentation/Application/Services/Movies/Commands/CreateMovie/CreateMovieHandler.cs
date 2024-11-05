using Domain.Common.Helper;
using MediatR;
using FluentValidation;
using Domain.Abstraction;
using Microsoft.Extensions.Logging;
using Application.Common.Mapping;

namespace Application.Services.Movies.Commands.CreateMovie;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, Result<CreateMovieResponse, ValidationException>>
{
    private readonly IMovieRepository _repositoryMovie;
    private readonly ILogger<CreateMovieHandler> _logger;
    private readonly IValidator<CreateMovieCommand> _validator;

    public CreateMovieHandler(ILogger<CreateMovieHandler> logger, IValidator<CreateMovieCommand> validator, IMovieRepository repositoryMovie)
    {
        _logger = logger;
        _repositoryMovie = repositoryMovie;
        _validator = validator;
    }

    public async Task<Result<CreateMovieResponse, ValidationException>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(CreateMovieHandler));
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationException(validationResult.Errors);
        }
        var result = await _repositoryMovie.AddAsync(request.ToDao());
        return new CreateMovieResponse(result.Value);
    }
}
