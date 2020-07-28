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

        protected override Task OnInitializedAsync()
        {
            this.Logger.LogInformation(nameof(this.OnInitializedAsync));
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            this.Logger.LogInformation(nameof(this.OnParametersSetAsync));
            return base.OnParametersSetAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            this.Logger.LogInformation(nameof(this.OnAfterRenderAsync));
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override bool ShouldRender()
        {
            this.Logger.LogInformation(nameof(this.ShouldRender));
            return base.ShouldRender();
        }
    }
}
