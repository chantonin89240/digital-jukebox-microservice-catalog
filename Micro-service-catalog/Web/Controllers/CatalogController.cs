using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Catalogs.Queries;
using Application.Catalogs.Commands.AddSongCatalog;
using Application.Catalogs.Queries.GetTrackById;

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

    // recherche depuis deezer de tracks
    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetSearchDeezer(string search)
    {
        var query = new Application.Catalogs.Queries.SearchDeezer.SearchDeezerQuery(search); 
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    // retour toutes les track d'un catalog
    [HttpGet("{idbar}")]
    public async Task<IActionResult> GetTrackCatalog(int idbar)
    {
        //var query = new Application.Catalogs.Queries.SearchDeezer.SearchDeezerQuery(search);
        //var result = await _mediator.Send(query);

        return Ok();
    }

    // retourne le track du catalog
    [HttpGet("bar/{idbar}/track/{idtrack}")]
    public async Task<IActionResult> GetTrackCatalogById(int idbar, int idtrack)
    {
        GetTrackByIdDto getTrackByIdDto = new GetTrackByIdDto() { IdBar = idbar, IdTrack = idtrack };
        var query = new GetTrackByIdQuery(getTrackByIdDto);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    // ajout de sons dans le catalog
    [HttpPost]
    public async Task<IActionResult> AddSongCatalog([FromBody] AddSongCatalogCommand command)
    {
        int retour = await _mediator.Send(command);

        if(retour == 1) 
        {
            return Ok();
        }
        else
        {
            return Conflict();
        }
    }

}
