using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Covid.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CovidCounterController : ControllerBase
    {
        public CovidCounterController(IDistributedCache cache)
        {
            Cache = cache;
        }

        public IDistributedCache Cache { get; }

        [HttpGet]
        public async Task<IActionResult> GetCounterAsync(string area)
        {
            var count = await Cache.GetStringAsync($"{area}.Counter");

            if (string.IsNullOrEmpty(count))
                return this.NotFound(area);
            else
                return this.Ok(new AreaCounter(area, count));
        }

        [HttpPost]
        public async Task<IActionResult> PublishCounterAsync([FromForm] AreaCounter counter)
        {
            try
            {
                await Cache.SetStringAsync($"{counter.Area}.Counter", counter.Count);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }
    }
}
