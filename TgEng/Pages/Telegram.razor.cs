using Microsoft.AspNetCore.Components;
using TgEng.Services;

namespace TgEng.Pages {
    public partial class Telegram {
        [Inject]
        public ITelegramWebAppProvider TelegramWebAppProvider { get; set; }

        [Parameter]
        public string Version { get; set; }

        [Parameter]
        public string Platform { get; set; }

        [Parameter]
        public bool IsExpand { get; set; }

        protected override async Task OnInitializedAsync() {
            await TelegramWebAppProvider.InitializeAsync();

            Version = await TelegramWebAppProvider.GetVersionAsync();
            Platform = await TelegramWebAppProvider.GetPlatformAsync();
            IsExpand = await TelegramWebAppProvider.GetIsExpandedAsync();
        }
    }
}
