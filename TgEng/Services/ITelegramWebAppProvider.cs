namespace TgEng.Services {
    /// <summary>
    /// Telegram WebApp property provider
    /// </summary>
    public interface ITelegramWebAppProvider : IAsyncDisposable, IInitializable {
        /// <summary>
        /// Get IsExpanded property
        /// </summary>
        ValueTask<bool> GetIsExpandedAsync();

        /// <summary>
        /// Get version property
        /// </summary>
        ValueTask<string> GetVersionAsync();

        /// <summary>
        /// Get platform property
        /// </summary>
        ValueTask<string> GetPlatformAsync();

        /// <summary>
        /// Call Expand WebApp method
        /// </summary>
        ValueTask InvokeExpandAsync();

        /// <summary>
        /// Call Close WebApp method
        /// </summary>
        ValueTask InvokeCloseAsync();
    }
}
