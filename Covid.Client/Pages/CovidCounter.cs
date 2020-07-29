using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Covid.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Covid.Client.Pages
{
    public partial class CovidCounter : ComponentBase
    {
        private const string GetCountUrl = "/api/CovidCounter/GetCounter?Area={0}";

        [Inject]
        public ILogger<CovidCounter> Logger { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            int? count = null;
            try
            {
                this.Logger.LogInformation($"{nameof(this.OnParametersSetAsync)}: {nameof(this.Area)}={this.Area}");
                var areaCounter = await this.HttpClient.GetFromJsonAsync<AreaCounter>(string.Format(GetCountUrl, this.Area));
                count = int.TryParse(areaCounter.Count, out int result) ? new int?(result) : null;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, $"{nameof(this.OnParametersSetAsync)}: {nameof(this.Area)}={this.Area}");
            }
            finally
            {
                this.Count = count;
            }

            await base.OnParametersSetAsync();
        }
    }
}
