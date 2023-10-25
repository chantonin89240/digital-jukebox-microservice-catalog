using Application.Catalogs.Queries.SearchDeezer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IDeezerService
{
    Task<RootDeezerDto> GetSearchDeezerAsync(string search);
}
