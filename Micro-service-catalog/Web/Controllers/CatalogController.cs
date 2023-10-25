using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Catalogs.Queries;

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

    [HttpGet("{search}")]
    public async Task<IActionResult> GetSearchDeezer(string search)
    {
        var query = new Application.Catalogs.Queries.SearchDeezer.SearchDeezerQuery(search);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
