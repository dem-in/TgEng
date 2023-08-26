using Microsoft.AspNetCore.Components;
using TgEng.Services;

namespace TgEng.Shared {
    public partial class NavMenu {
        [Inject]
        public ITelegramWebAppProvider TelegramWebAppProvider { get; set; }

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu() {
            collapseNavMenu = !collapseNavMenu;
        }

        private async Task CloseAsync() {
            await TelegramWebAppProvider.InvokeCloseAsync();
        }

        protected override async Task OnInitializedAsync() {
            await TelegramWebAppProvider.InitializeAsync();
        }
    }
}
