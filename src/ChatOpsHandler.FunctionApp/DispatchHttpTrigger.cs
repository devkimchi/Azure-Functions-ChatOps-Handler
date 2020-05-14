using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using ChatOpsHandler.FunctionApp.Configs;
using ChatOpsHandler.FunctionApp.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;


namespace ChatOpsHandler.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity to invoke the repository_dispatch event on GitHub.
    /// </summary>
    public class DispatchHttpTrigger
    {
        private readonly AppSettings _settings;
        private readonly HttpClient _client;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInvokeHttpTrigger"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="client"><see cref="HttpClient"/> instance.</param>
        public DispatchHttpTrigger(AppSettings settings, HttpClient client)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Invokes the GitHub repository_dispatch event.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the event payload requested.</returns>
        [FunctionName(nameof(DispatchHttpTrigger.Run))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "actions/run")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = default(string);
            var payload = default(EventRequest);
            using (var reader = new StreamReader(req.Body))
            {
                body = await reader.ReadToEndAsync();
                payload = JsonConvert.DeserializeObject<EventRequest>(body);
            }

            req.HttpContext.Response.Headers.Add("CARD-ACTION-STATUS", $"Deployment process for {payload.ClientPayload.Artifact.Name} has been resumed.");

            using (var content = new StringContent(body))
            {
                var authKey = this._settings.GitHub.AuthKey;
                var endpoint = string.Format(this._settings.GitHub.Endpoints.Dispatches.TrimStart('/'), payload.ClientPayload.Repository.Owner, payload.ClientPayload.Repository.Name);
                var requestUri = new Uri($"{this._settings.GitHub.BaseUri.TrimEnd('/')}/{endpoint}");
                var accept = this._settings.GitHub.Headers.Accept;
                var userAgent = this._settings.GitHub.Headers.UserAgent;

                this._client.DefaultRequestHeaders.Clear();
                this._client.DefaultRequestHeaders.Add("Authorization", authKey);
                this._client.DefaultRequestHeaders.Add("Accept", accept);
                this._client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                using (var response = await this._client.PostAsync(requestUri, content).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            var result = new AcceptedResult(new Uri($"https://github.com/{payload.ClientPayload.Repository.Owner}/{payload.ClientPayload.Repository.Name}/actions"), body);

            return result;
        }
    }
}
