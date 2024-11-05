using Domain.Common.Helper;
using FluentValidation;
using MediatR;

namespace Application.Services.Movies.Commands.CreateMovie;

public record CreateMovieCommand(string Title, string Author, DateTime ReleaseDate) : IRequest<Result<CreateMovieResponse, ValidationException>>;
