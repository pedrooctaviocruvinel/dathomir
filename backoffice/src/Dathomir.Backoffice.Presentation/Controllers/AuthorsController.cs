using Dathomir.Backoffice.Application.Authors.GetAuthorDetailsById;
using Dathomir.Backoffice.Application.Authors.RegisterAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dathomir.Backoffice.Presentation.Controllers;

[Route("authors")]
[ApiController]
public class AuthorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetDetailsById([FromRoute] GetAuthorDetailsByIdQueryRequest queryRequest)
    {
        var getAuthorDetailsByIdResult = await mediator.Send(queryRequest);

        if (!getAuthorDetailsByIdResult.Success)
            return NotFound(getAuthorDetailsByIdResult);

        return Ok(getAuthorDetailsByIdResult);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterAuthorCommandRequest commandRequest)
    {
        var registerAuthorResult = await mediator.Send(commandRequest);

        if (!registerAuthorResult.Success)
            return BadRequest(registerAuthorResult);

        return CreatedAtAction(nameof(GetDetailsById), new { Id = registerAuthorResult.Data.Id }, registerAuthorResult);
    }
}
