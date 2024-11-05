using Domain.Abstraction;
using Domain.Common.Helper;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Repositories;

public class MovieRepository(ILogger<MovieRepository> logger, WriterContext context) : IMovieRepository
{
    private readonly ILogger<MovieRepository> _logger = logger;
    private readonly WriterContext _context = context;

    public async Task<Movie?> GetMovieByIdAsync(Guid movieId, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(GetMovieByIdAsync));
        return await _context.Movies.FindAsync(movieId);
    }


    public async Task<Result<Guid, Exception>> AddAsync(Movie movie)
    {
        _logger.LogInformation(nameof(AddAsync));
        _context.Add(movie);
        var isSaved = await _context.SaveChangesAsync() > 0;
        return isSaved ? movie.Id : new Exception("Movie wasn't saved");
    }

    public async Task<Result<bool, Exception>> UpdateAsync(IMovieDto movieDto)
    {
        _logger.LogInformation(nameof(UpdateAsync));
        Movie? movie = await _context.Movies.FindAsync(movieDto.Id);
        if (movie is not null)
        {
            movie.Author = movieDto.Author;
            movie.Title = movieDto.Title;
            movie.ReleaseDate = movieDto.ReleaseDate;
            _context.Movies.Update(movie);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        _logger.LogInformation(nameof(RemoveAsync));
        Movie? movie = await _context.Movies.FindAsync(id);
        if (movie is not null)
        {
            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}
