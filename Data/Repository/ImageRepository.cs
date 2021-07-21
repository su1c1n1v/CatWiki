using CatWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CatWiki.Data.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _Client;
        private HttpResponseMessage _response;
        private ImageViewModel images;
        private string getImages;

        public ImageRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<ImageViewModel> GetImageById(string id)
        {
            getImages = "https://api.thecatapi.com/v1/images/"+id;
            var request = new HttpRequestMessage(HttpMethod.Get, getImages);

            _Client = _clientFactory.CreateClient();

            _response = await _Client.SendAsync(request);
            if (!_response.IsSuccessStatusCode)
            {
                return null;
            }

            images = await _response.Content.ReadFromJsonAsync<ImageViewModel>();

            return images;
        }
    }
}
