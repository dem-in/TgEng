using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TgEng.Pages {
    public partial class Telegram {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;

        [Parameter]
        public string BotApiVersion { get; set; }

        protected override async Task OnInitializedAsync() {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/script.js");

            BotApiVersion = await _jsModule.InvokeAsync<string>("GetTelegramBotApiVersion");
        }
    }
}
