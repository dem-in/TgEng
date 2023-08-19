using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TgEng.Shared {
    public partial class NavMenu {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu() {
            collapseNavMenu = !collapseNavMenu;
        }

        private async Task CloseAsync() {
            await _jsModule.InvokeVoidAsync("Close");
        }

        protected override async Task OnInitializedAsync() {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts.js");
        }
    }
}
