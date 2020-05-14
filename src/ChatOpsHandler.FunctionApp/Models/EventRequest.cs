using Newtonsoft.Json;

namespace ChatOpsHandler.FunctionApp.Models
{
    /// <summary>
    /// This represents the event request entity.
    /// </summary>
    public class EventRequest
    {
        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        [JsonProperty("event_type")]
        public virtual string EventType { get; set; }

        /// <summary>
        /// Gets or sets the client payload details.
        /// </summary>
        [JsonProperty("client_payload")]
        public virtual ClientPayload ClientPayload { get; set; }
    }

    /// <summary>
    /// This represents the client payload entity.
    /// </summary>
    public class ClientPayload
    {
        /// <summary>
        /// Gets or sets the artifact details.
        /// </summary>
        [JsonProperty("artifact")]
        public virtual ArtifactDetails Artifact { get; set; }

        /// <summary>
        /// Gets or sets the repository details.
        /// </summary>
        [JsonProperty("repository")]
        public virtual RepositoryDetails Repository { get; set; }
    }

    /// <summary>
    /// This represents the artifact details entity.
    /// </summary>
    public class ArtifactDetails
    {
        /// <summary>
        /// Gets or sets the artifact name.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }
    }

    /// <summary>
    /// This represents the repository details entity.
    /// </summary>
    public class RepositoryDetails
    {
        /// <summary>
        /// Gets or sets the repository name.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the repository owner.
        /// </summary>
        [JsonProperty("owner")]
        public virtual string Owner { get; set; }
    }
}