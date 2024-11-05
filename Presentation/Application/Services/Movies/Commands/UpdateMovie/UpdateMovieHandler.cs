using Domain.Abstraction;
using Domain.Common.Helper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Services.Movies.Commands.UpdateMovie;

public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Result<UpdateMovieResponse, ValidationException>>
{
    private readonly ILogger<UpdateMovieHandler> _logger;
    private readonly IMovieRepository _movieRepository;
    private readonly IValidator<UpdateMovieCommand> _validator;
    public UpdateMovieHandler(ILogger<UpdateMovieHandler> logger, IValidator<UpdateMovieCommand> validator, IMovieRepository repositoryWriter)
    {
        _logger = logger;
        _movieRepository = repositoryWriter;
        _validator = validator;
    }

    public async Task<Result<UpdateMovieResponse, ValidationException>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(UpdateMovieHandler));
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new ValidationException(validationResult.Errors);
        }
        var result = await _movieRepository.UpdateAsync(request.MovieDto);
        return new UpdateMovieResponse(result.Value);
    }
}
