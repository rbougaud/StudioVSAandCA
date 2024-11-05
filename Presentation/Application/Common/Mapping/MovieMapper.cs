using Application.Common.Dto.Movie;
using Application.Services.Movies.Commands.CreateMovie;
using Domain.Abstraction;
using Domain.Entities;

namespace Application.Common.Mapping;

public static class MovieMapper
{
    public static Movie ToDao(this CreateMovieCommand command)
    {
        return new Movie
        {
            Id = Ulid.NewUlid().ToGuid(),
            Title = command.Title,
            Author = command.Author,
            ReleaseDate = command.ReleaseDate
        };
    }

    public static IMovieDto ToDto(this Movie? movie)
    {
        if (movie is null) { return new MovieDtoNotFound(); }
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Author = movie.Author,
            ReleaseDate = movie.ReleaseDate
        };
    }
}
