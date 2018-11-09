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
        [HttpGet("ping")]
        public ActionResult<BasicResponse> Ping()
        {
            return new BasicResponse { Message = "pong" };
        }


        [HttpGet("launches/upcoming")]
        public async Task<ActionResult<IEnumerable<SpaceXLaunch>>> GetImageOfTheDay()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://api.spacexdata.com/v3/launches/upcoming");
            // TODO, cache things!
            // response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<IEnumerable<SpaceXLaunch>>();
            return Ok(result);
        }
    }
}