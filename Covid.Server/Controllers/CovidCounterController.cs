using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var result = await Cache.GetStringAsync($"{area}.Counter");

            if (string.IsNullOrEmpty(result))
                return this.NotFound(area);
            else
                return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PublishCounterAsync(string area, string count)
        {
            try
            {
                await Cache.SetStringAsync($"{area}.Counter", count);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }
    }
}
