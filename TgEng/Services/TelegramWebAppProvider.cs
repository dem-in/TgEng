using Microsoft.JSInterop;

namespace TgEng.Services {
    public class TelegramWebAppProvider : ITelegramWebAppProvider {
        private Lazy<IJSObjectReference> _jSModule = new();

        private readonly IJSRuntime _jSRuntime;

        public TelegramWebAppProvider(IJSRuntime runtime) {
            _jSRuntime = runtime ?? throw new ArgumentNullException(nameof(runtime));
        }

        public async ValueTask DisposeAsync() {
            if (_jSModule.IsValueCreated)
                await _jSModule.Value.DisposeAsync();
        }

        public async ValueTask InitializeAsync() {
            _jSModule = new(await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts.js"));
        }

        public ValueTask ExpandAsync() {
            throw new NotImplementedException();
        }

        public ValueTask<bool> GetIsExpandedAsync() {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetPlatformAsync() {
            throw new NotImplementedException();
        }

        public async ValueTask<string> GetVersionAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");
            return await _jSModule.Value.InvokeAsync<string>("GetWebAppVersion");
        }
    }
}
