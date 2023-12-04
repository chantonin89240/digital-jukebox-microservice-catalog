using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.SearchDeezer;

public class RootDeezerDto
{
    public List<DeezerDto>? Data { get; set; }
    public long Total { get; set; }
    public string Next { get; set; }
}
