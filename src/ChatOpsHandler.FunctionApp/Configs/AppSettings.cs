using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings;
using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings.Extensions;

namespace ChatOpsHandler.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings : AppSettingsBase
    {
        private const string GitHubSettingsKey = "GitHub";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
            : base()
        {
            this.GitHub = this.Config.Get<GitHubSettings>(GitHubSettingsKey);
        }

        /// <summary>
        /// Gets the <see cref="GitHubSettings"/> instance.
        /// </summary>
        public virtual GitHubSettings GitHub { get; }
    }
}