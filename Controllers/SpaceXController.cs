using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AstroAPI.ViewModels;

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
    }
}