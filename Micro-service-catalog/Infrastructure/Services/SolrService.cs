using System;
using System.Text;
using Application.Catalogs.Queries;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
	public class SolrService
	{
		private readonly string _baseUrl;
		private readonly HttpClient _httpClient;

		public SolrService(string baseUrl)
		{
			_baseUrl = baseUrl;
			_httpClient = new HttpClient();
		}

		public async Task AddAsync(TrackDto track)
		{
            HttpResponseMessage response = await _httpClient.PostAsync(
                $"{_baseUrl}solr/tracks/update",
                new StringContent(JsonConvert.SerializeObject(
                    new List<TrackDto>() {
                        track
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            );
        }
	}
}

