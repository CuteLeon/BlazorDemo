using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Covid.Client.Pages
{
    public partial class CovidCounters : ComponentBase
    {
        [Inject]
        public ILogger<CovidCounters> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Logger.LogInformation(nameof(this.OnInitializedAsync));
            this.Areas = Enumerable.Range(-2, 12).Select(number => $"C_{number}");
            await base.OnInitializedAsync();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            this.Logger.LogInformation($"{nameof(SetParametersAsync)} with {parameters.ToDictionary().Count()} parameters.");
            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnParametersSetAsync()
        {
            this.Logger.LogInformation(nameof(this.OnParametersSetAsync));
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this.Logger.LogInformation(nameof(this.OnAfterRenderAsync));
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override bool ShouldRender()
        {
            this.Logger.LogInformation(nameof(this.ShouldRender));
            return base.ShouldRender();
        }
    }
}
