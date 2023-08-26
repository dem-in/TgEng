namespace TgEng.Services {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddSingleton<ITelegramWebAppProvider, TelegramWebAppProvider>();
    }
}
