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

        public async ValueTask InvokeExpandAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");

            await _jSModule.Value.InvokeVoidAsync("WebAppExpand");
        }

        public async ValueTask InvokeCloseAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");

            await _jSModule.Value.InvokeVoidAsync("WebAppClose");
        }

        public async ValueTask<bool> GetIsExpandedAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");

            return await _jSModule.Value.InvokeAsync<bool>("WebAppIsExpanded");
        }

        public async ValueTask<string> GetPlatformAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");

            return await _jSModule.Value.InvokeAsync<string>("WebAppPlatform");
        }

        public async ValueTask<string> GetVersionAsync() {
            if (!_jSModule.IsValueCreated)
                throw new NullReferenceException($"{nameof(_jSModule)} is not created");

            return await _jSModule.Value.InvokeAsync<string>("WebAppVersion");
        }
    }
}
