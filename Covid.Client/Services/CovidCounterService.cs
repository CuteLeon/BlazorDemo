using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Covid.Shared;
using Microsoft.Extensions.Logging;

namespace Covid.Client.Services
{
    public class CovidCounterService : HttpServiceBase, ICovidCounterService
    {
        public CovidCounterService(
            HttpClient httpClient,
            ILogger<CovidCounterService> logger)
            : base(httpClient)
        {
            Logger = logger;
        }

        private const string GetCountUrl = "/api/CovidCounter/GetCounter?Area={0}";
        private const string PublishCountUrl = "/api/CovidCounter/PublishCounter";

        public ILogger<CovidCounterService> Logger { get; }

        public async Task<AreaCounter> GetAreaCounterAsync(string area)
        {
            this.Logger.LogInformation($"{nameof(GetAreaCounterAsync)}: Area={area}");
            try
            {
                return await this.HttpClient.GetFromJsonAsync<AreaCounter>(string.Format(GetCountUrl, area));
            }
            catch (Exception ex)
            {
                this.Logger.LogWarning(ex, $"{nameof(GetAreaCounterAsync)}: Failed to get area counter.");
                throw;
            }
        }

        public async Task<bool> PublishCounterAsync(AreaCounter areaCounter)
        {
            this.Logger.LogInformation($"{nameof(PublishCounterAsync)}: {areaCounter.Area}=>{areaCounter.Count}");
            try
            {
                var response = await HttpClient.PostAsJsonAsync(PublishCountUrl, areaCounter);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                this.Logger.LogWarning(ex, $"{nameof(PublishCounterAsync)}: Failed to get area counter.");
                return false;
            }
        }
    }
}
