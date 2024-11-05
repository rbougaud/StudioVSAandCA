using Domain.Abstraction;
using Domain.Common.Helper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Services.Movies.Commands.DeleteMovie;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, Result<DeleteMovieResponse, ValidationException>>
{
    private readonly ILogger<DeleteMovieHandler> _logger;
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieHandler(ILogger<DeleteMovieHandler> logger, IMovieRepository movieRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }

    public async Task<Result<DeleteMovieResponse, ValidationException>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(DeleteMovieHandler));
        var result = await _movieRepository.RemoveAsync(request.Id);
        return new DeleteMovieResponse(result);
    }
}
