using Microsoft.AspNetCore.Components;
using TgEng.Services;

namespace TgEng {
    public partial class App {
        [Inject]
        public ITelegramWebAppProvider TelegramWebAppProvider { get; set; }

        protected override async Task OnInitializedAsync() {
            await TelegramWebAppProvider.InitializeAsync();

            await TelegramWebAppProvider.InvokeExpandAsync();
        }
    }
}
