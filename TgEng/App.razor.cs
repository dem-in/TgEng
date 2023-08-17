using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TgEng {
    public partial class App {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;

        protected override async Task OnInitializedAsync() {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts.js");

            await _jsModule.InvokeVoidAsync("Expand");
        }
    }
}
