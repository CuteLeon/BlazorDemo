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
            this.Logger.LogInformation($"{nameof(this.OnParametersSetAsync)}: {nameof(this.Area)}={this.Area}");
            var countString = await this.HttpClient.GetFromJsonAsync<AreaCounter>(string.Format(GetCountUrl, this.Area));
            this.Logger.LogWarning($"调试: {nameof(countString)}={countString}");

            // this.Count = int.TryParse(countString, out int result) ? new int?(result) : null;

            await base.OnParametersSetAsync();
        }
    }
}
