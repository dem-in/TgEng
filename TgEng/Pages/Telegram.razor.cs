using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TgEng.Services;

namespace TgEng.Pages {
    public partial class Telegram {
        //[Inject]
        //public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public ITelegramWebAppProvider TelegramWebAppProvider { get; set; }

        private IJSObjectReference _jsModule;

        [Parameter]
        public string BotApiVersion { get; set; }

        //protected override async Task OnInitializedAsync() {
        //    _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts.js");

        //    BotApiVersion = await _jsModule.InvokeAsync<string>("GetTelegramBotApiVersion");
        //}

        protected override async Task OnInitializedAsync() {
            await TelegramWebAppProvider.InitializeAsync();
        }
    }
}
