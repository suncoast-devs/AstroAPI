using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AstroAPI.ViewModels;
using System.Net.Http;

namespace AstroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceXController : ControllerBase
    {
        readonly Cache.CacheService _cache;
        public SpaceXController()
        {
            _cache = new Cache.CacheService();
        }
        
        [Produces("application/json")]
        [HttpGet("ping")]
        public ActionResult<BasicResponse> Ping()
        {
            return new BasicResponse { Message = "pong" };
        }

        [Produces("application/json")] 
        [HttpGet("launches/upcoming")]
        public async Task<ActionResult<IEnumerable<SpaceXLaunch>>> GetImageOfTheDay()
        {
            var client = new HttpClient();
            var service = new Cache.CacheService();
            var url = $"https://api.spacexdata.com/v3/launches/upcoming";
            var cached = await service.GetItem(url);
            if (cached == null)
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsAsync<IEnumerable<SpaceXLaunch>>();
                await service.InsertItem(url, result);
                return Ok(result);
            }
            else
            {
                var rv = cached.Content as IEnumerable<SpaceXLaunch>;
                return Ok(rv);
            }
        }
    }
}