using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Timers;
using Covid.Client.Services;
using Covid.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Covid.Client.Pages
{
    public partial class CovidCounter : ComponentBase, IDisposable
    {
        protected readonly Timer Timer = new Timer(3000) { AutoReset = true };
        protected readonly Random Random = new Random();

        [Inject]
        public ILogger<CovidCounter> Logger { get; set; }

        [Inject]
        public ICovidCounterService CovidCounterService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Logger.LogWarning($"Timer_Elapsed: Area={Area}, Count={Count}");
            await this.InvokeAsync(() =>
              {
                  if (!this.Count.HasValue) return;

                  this.Count += Random.Next(-100, 120);
                  // Notify to re-render
                  this.StateHasChanged();
              });
        }

        protected override async Task OnParametersSetAsync()
        {
            this.Logger.LogInformation($"{nameof(this.OnParametersSetAsync)}: {nameof(this.Area)}={this.Area}");
            await RefreshCount();

            await base.OnParametersSetAsync();
        }

        public async Task RefreshCount()
        {
            int? count = null;
            try
            {
                this.Logger.LogInformation($"{nameof(this.RefreshCount)}: {nameof(this.Area)}={this.Area}");
                var areaCounter = await this.CovidCounterService.GetAreaCounterAsync(this.Area);
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
        }

        public void Dispose()
        {
            Timer.Stop();
            Timer.Dispose();
        }
    }
}
