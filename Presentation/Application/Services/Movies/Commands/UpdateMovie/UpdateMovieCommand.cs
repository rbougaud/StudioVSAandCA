using Application.Common.Dto.Movie;
using Domain.Common.Helper;
using FluentValidation;
using MediatR;

namespace Application.Services.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(MovieDto MovieDto) : IRequest<Result<UpdateMovieResponse, ValidationException>>;
