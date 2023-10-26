using Application.Common.Interfaces;
using MediatR;

namespace Application.Catalogs.Queries.SearchDeezer;

public record SearchDeezerQuery(string search) : IRequest<List<DeezerDto>> { }

public class SearchDeezerHandler : IRequestHandler<SearchDeezerQuery, List<DeezerDto>>
{
    private readonly IDeezerService _deezerService;

    public SearchDeezerHandler(IDeezerService deezerService)
    {
        this._deezerService = deezerService;
    }

    public async Task<List<DeezerDto>> Handle(SearchDeezerQuery request, CancellationToken cancellationToken)
    {
        RootDeezerDto resultDeezer = await _deezerService.GetSearchDeezerAsync(request.search);


        List<DeezerDto> deezer = new List<DeezerDto>();

        foreach (DeezerDto Deez in resultDeezer.Data)
        {
            deezer.Add(Deez);
        }


        return deezer;
    }
}
