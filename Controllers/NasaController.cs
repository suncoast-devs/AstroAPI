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
        readonly Cache.CacheService _cache;

        private string NASA_API_KEY = "";
        public NasaController(IConfiguration configuration)
        {
            _configuration = configuration;
            NASA_API_KEY = _configuration.GetValue<string>("NASA_API_KEY");
            _cache = new Cache.CacheService();
        }


        [Produces("application/json")]
        [HttpGet("ping")]
        public ActionResult<BasicResponse> Ping()
        {
            return new BasicResponse { Message = "ponged at " + DateTime.Now };
        }

        [HttpGet("apod")]
        [Produces("application/json")]
        public async Task<ActionResult<NasaResponse>> GetImageOfTheDay()
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={this.NASA_API_KEY}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<NasaResponse>();
            return result;
        }


    }
}