using Application.Services.Movies.Commands.CreateMovie;
using Application.Services.Movies.Commands.DeleteMovie;
using Application.Services.Movies.Commands.UpdateMovie;
using Application.Services.Movies.Queries.GetMovieById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("[action]")]
    public async Task<IActionResult> GetMovieById(GetMovieByIdRequest request)
    {
        var query = new GetMovieByIdQuery(request.Id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand request)
    {
        var result = await _mediator.Send(request);
        return result.Match<IActionResult>
               (
                   v => Ok(v),
                   failed => BadRequest(failed)
               );
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand request)
    {
        var result = await _mediator.Send(request);
        return result.Match<IActionResult>
               (
                   v => Ok(v),
                   failed => BadRequest(failed)
               );
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteMovie([FromBody] DeleteMovieCommand request)
    {
        var result = await _mediator.Send(request);
        return result.Match<IActionResult>
               (
                   v => Ok(v),
                   failed => BadRequest(failed)
               );
    }
}
