using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AstroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<object>>Get()
        {
            return await new Cache.CacheService().InsertItem("some url", new { data = "goes here" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            return await new Cache.CacheService().GetItem("some url");
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
