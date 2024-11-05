using Domain.Abstraction;

namespace Application.Common.Dto.Movie;

public record MovieDto : IMovieDto
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public DateTime ReleaseDate { get; init; }
}
