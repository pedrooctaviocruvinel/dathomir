using Dathomir.Backoffice.Application.Mangas.RegisterManga;
using Dathomir.Backoffice.CrossCutting.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dathomir.Backoffice.Presentation.Controllers;

[Route("mangas")]
[ApiController]
public class MangasController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterMangaCommandRequest commandRequest)
    {
        var registerMangaResult = await mediator.Send(commandRequest);

        if (!registerMangaResult.Success)
        {
            if (registerMangaResult.ErrorCode == ErrorCode.AuthorDoesntExists)
                return NotFound(registerMangaResult);

            if (registerMangaResult.ErrorCode == ErrorCode.EntityValidationError)
                return BadRequest(registerMangaResult);
        }

        return CreatedAtAction(nameof(GetById), new { id = registerMangaResult.Data.Id }, registerMangaResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok();
    }
}
