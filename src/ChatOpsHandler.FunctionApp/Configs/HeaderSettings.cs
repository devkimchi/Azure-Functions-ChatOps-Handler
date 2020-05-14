namespace ChatOpsHandler.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for GitHub API headers.
    /// </summary>
    public class HeaderSettings
    {
        /// <summary>
        /// Gets or sets the "Accept" header value.
        /// </summary>
        public virtual string Accept { get; set; }

        /// <summary>
        /// Gets or sets the "User-Agent" header value.
        /// </summary>
        public virtual string UserAgent { get; set; }
    }
}