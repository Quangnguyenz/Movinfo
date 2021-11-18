using Microsoft.AspNetCore.Http;
using MovieProDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieProDemo.Services
{
    public class BasicImageService : IImageService
    {
        private readonly IHttpClientFactory _httpClient;
        public string DecodeImage(byte[] poster, string contenType)
        {
            if (poster == null) return null;
            
            var posterImage = Convert.ToBase64String(poster);
            return $"data:{contenType};base64,{posterImage}";
            
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile poster)
        {
            if (poster == null) return null;

            var ms = new MemoryStream();
            await poster.CopyToAsync(ms);
            return ms.ToArray();

        }

        public async Task<byte[]> EncodeImageURLAsync(string imageURL)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync(imageURL);
            using Stream stream = await response.Content.ReadAsStreamAsync();

            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
