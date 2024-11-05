using Domain.Abstraction;

namespace Application.Services.Movies.Queries.GetMovieById;

public record GetMovieByIdResponse(IMovieDto Movie);
