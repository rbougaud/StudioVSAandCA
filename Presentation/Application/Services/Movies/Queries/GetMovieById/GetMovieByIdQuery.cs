using MediatR;

namespace Application.Services.Movies.Queries.GetMovieById;

public record GetMovieByIdQuery(Guid MovieId) : IRequest<GetMovieByIdResponse>;
