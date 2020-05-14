using ChatOpsHandler.FunctionApp.Configs;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ChatOpsHandler.FunctionApp.StartUp))]
namespace ChatOpsHandler.FunctionApp
{
    /// <summary>
    /// This represents the startup entity as an IoC container.
    /// </summary>
    public class StartUp : FunctionsStartup
    {
        /// <inheritdoc />
        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.ConfigureAppSettings(builder.Services);
            this.ConfigureHttpClient(builder.Services);
        }

        public void ConfigureAppSettings(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();
        }

        private void ConfigureHttpClient(IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}