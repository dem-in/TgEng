using Microsoft.AspNetCore.Components;
using TgEng.Services;

namespace TgEng.Pages {
    public partial class Telegram {
        [Inject]
        public ITelegramWebAppProvider TelegramWebAppProvider { get; set; }

        [Parameter]
        public string BotApiVersion { get; set; }

        protected override async Task OnInitializedAsync() {
            await TelegramWebAppProvider.InitializeAsync();

            BotApiVersion = await TelegramWebAppProvider.GetVersionAsync();
        }
    }
}
