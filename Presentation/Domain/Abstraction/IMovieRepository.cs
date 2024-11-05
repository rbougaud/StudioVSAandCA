using Domain.Common.Helper;
using Domain.Entities;

namespace Domain.Abstraction;

public interface IMovieRepository
{
    Task<Result<Guid, Exception>> AddAsync(Movie movie);
    Task<Movie?> GetMovieByIdAsync(Guid movieId, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(Guid id);
    Task<Result<bool, Exception>> UpdateAsync(IMovieDto movieDto);
}
