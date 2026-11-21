using Dathomir.Backoffice.Application.Authors.RegisterAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dathomir.Backoffice.Presentation.Controllers;

[Route("authors")]
[ApiController]
public class AuthorsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterAuthorCommandRequest commandRequest)
    {
        var registerAuthorResult = await mediator.Send(commandRequest);

        if (!registerAuthorResult.Success)
            return BadRequest(registerAuthorResult);

        return CreatedAtAction(nameof(GetById), new { id = registerAuthorResult.Data.Id }, registerAuthorResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }
}
