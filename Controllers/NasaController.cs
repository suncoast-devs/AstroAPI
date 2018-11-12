using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AstroAPI.ViewModels;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace AstroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaController : ControllerBase
    {

        readonly IConfiguration _configuration;

        private string NASA_API_KEY = "";
        public NasaController(IConfiguration configuration)
        {
            _configuration = configuration;
            NASA_API_KEY = _configuration.GetValue<string>("NASA_API_KEY");

        }
        [HttpGet("ping")]
        public ActionResult<BasicResponse> Ping()
        {
            return new BasicResponse { Message = "pong" };
        }

        [HttpGet("apod")]
        public async Task<ActionResult<NasaResponse>> GetImageOfTheDay()
        {
            var client = new HttpClient();
            var _url = $"https://api.nasa.gov/planetary/apod?api_key={this.NASA_API_KEY}";
            var service = new Cache.CacheService();
            var cached = await service.GetItem(_url);
            if (cached == null)
            {
                var response = await client.GetAsync(_url);
                var result = await response.Content.ReadAsAsync<NasaResponse>();
                await service.InsertItem(_url, result);
                result.FromCache = false;
                return result;
            }
            else
            {
                var rv = cached.Content as NasaResponse;
                rv.FromCache = true;
                return rv;
            }
            
        }

    }
}