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
        private List<Cats> cats;
        private string getBreeds;

        public CatsRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Cats>> GetAllCats()
        {

            getBreeds = "https://api.thecatapi.com/v1/breeds";
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

        public async Task<List<Cats>> GetQuantityOfCats(int quantity)
        {
            getBreeds = "https://api.thecatapi.com/v1/breeds?limit="+quantity+ "&page="+quantity;
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
            getBreeds = "https://api.thecatapi.com/v1/breeds/search?q=" + id;
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

        public async Task<List<Cats>> GetCatByName(string name)
        {
            getBreeds = "https://api.thecatapi.com/v1/breeds/search?q=" + name;
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
    }
}
