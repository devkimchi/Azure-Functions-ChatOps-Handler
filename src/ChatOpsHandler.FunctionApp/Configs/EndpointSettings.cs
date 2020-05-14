namespace ChatOpsHandler.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for GitHub API endpoints.
    /// </summary>
    public class EndpointSettings
    {
        /// <summary>
        /// Gets or sets the repository_dispatch endpoint.
        /// </summary>
        public virtual string Dispatches { get; set; }
    }
}