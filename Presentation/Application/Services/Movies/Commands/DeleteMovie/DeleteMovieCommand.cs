using Domain.Common.Helper;
using FluentValidation;
using MediatR;

namespace Application.Services.Movies.Commands.DeleteMovie;

public record DeleteMovieCommand(Guid Id) : IRequest<Result<DeleteMovieResponse, ValidationException>>;
