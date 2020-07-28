using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Covid.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CovidCounterController : ControllerBase
    {
        public CovidCounterController(ILogger<CovidCounterController> logger, IDistributedCache cache)
        {
            Logger = logger;
            Cache = cache;
        }

        public ILogger<CovidCounterController> Logger { get; }
        public IDistributedCache Cache { get; }

        [HttpGet]
        public async Task<IActionResult> GetCounterAsync(string area)
        {
            this.Logger.LogInformation($"Get Counter: {area}");
            var count = await Cache.GetStringAsync($"{area}.Counter");

            if (string.IsNullOrEmpty(count))
                return this.NotFound(area);
            else
                return this.Ok(new AreaCounter(area, count));
        }

        [HttpPost]
        public async Task<IActionResult> PublishCounterAsync([FromForm] AreaCounter counter)
        {
            this.Logger.LogWarning($"Publish Counter: {counter.Area} => {counter.Count}");
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
