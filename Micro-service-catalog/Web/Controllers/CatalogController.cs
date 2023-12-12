using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Catalogs.Queries;
using Application.Catalogs.Commands.AddSongCatalog;

namespace Web.Controllers;

[ApiController]
[Route("api/catalogs")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // recherche depuis deezer de sons
    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetSearchDeezer(string search)
    {
        var query = new Application.Catalogs.Queries.SearchDeezer.SearchDeezerQuery(search); 
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    // ajout de sons dans le catalog
    [HttpPost]
    public async Task<IActionResult> AddSongCatalog([FromBody] AddSongCatalogCommand command)
    {
        await _mediator.Send(command);

        return Ok("Song add catalog");
    }

}
