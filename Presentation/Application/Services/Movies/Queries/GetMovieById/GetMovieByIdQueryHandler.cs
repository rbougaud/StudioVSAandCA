using Domain.Abstraction;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Common.Mapping;

namespace Application.Services.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
{
    private readonly ILogger<GetMovieByIdQueryHandler> _logger;
    private readonly IMovieRepository _repositoryMovie;

    public GetMovieByIdQueryHandler(ILogger<GetMovieByIdQueryHandler> logger, IMovieRepository repositoryMovieReader)
    {
        _logger = logger;
        _repositoryMovie = repositoryMovieReader;
    }

    public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(GetMovieByIdQueryHandler));
        var movie = await _repositoryMovie.GetMovieByIdAsync(request.MovieId, cancellationToken);
        return new GetMovieByIdResponse(movie.ToDto());
    }
}
