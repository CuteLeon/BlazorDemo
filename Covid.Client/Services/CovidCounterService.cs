using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Covid.Shared;

namespace Covid.Client.Services
{
    public class CovidCounterService : HttpServiceBase, ICovidCounterService
    {
        public CovidCounterService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        private const string GetCountUrl = "/api/CovidCounter/GetCounter?Area={0}";

        public async Task<AreaCounter> GetAreaCounterAsync(string area)
            => await this.HttpClient.GetFromJsonAsync<AreaCounter>(string.Format(GetCountUrl, area));
    }
}
