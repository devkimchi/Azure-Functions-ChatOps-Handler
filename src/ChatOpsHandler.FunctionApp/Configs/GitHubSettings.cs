namespace ChatOpsHandler.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for GitHub.
    /// </summary>
    public class GitHubSettings
    {
        /// <summary>
        /// Gets or sets the GitHub API key.
        /// </summary>
        public virtual string AuthKey { get; set; }

        /// <summary>
        /// Gets or sets the GitHub API base URI.
        /// </summary>
        public virtual string BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the GitHub endpoints.
        /// </summary>
        public virtual EndpointSettings Endpoints { get; set; }

        /// <summary>
        /// Gets or sets the GitHub API request headers.
        /// </summary>
        public virtual HeaderSettings Headers { get; set; }
    }
}