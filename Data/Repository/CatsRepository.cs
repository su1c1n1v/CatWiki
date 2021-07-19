using CatWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CatWiki.Data.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private  HttpClient _Client;
        private HttpResponseMessage _response;

        public CatsRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Cats>> GetAllCats()
        {
            List<Cats> cats;
            string getBreeds;

            getBreeds = "https://api.thecatapi.com/v1/breeds?limit=4&page=4";
            var request = new HttpRequestMessage(HttpMethod.Get, getBreeds);

            _Client = _clientFactory.CreateClient();

            _response = await _Client.SendAsync(request);
            if (!_response.IsSuccessStatusCode)
            {
                return null;
            }

            cats = await _response.Content.ReadFromJsonAsync<List<Cats>>();

            return cats;
        }

        public async Task<List<Cats>> GetCatById(string id)
        {
            return null;
        }

        public async Task<List<Cats>> GetCatByName(string name)
        {
            return null;
        }
    }
}
