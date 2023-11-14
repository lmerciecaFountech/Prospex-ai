namespace SalesForce.Models
{
    /// <summary>
    /// Provides the information for salesforce services.
    /// </summary>
    public class Configuration
    {
        public Configuration(string accessToken, string instanceUrl, string apiVersion)
        {
            //Preconditions.CheckNotBlank(accessToken, nameof(accessToken));
            //Preconditions.CheckNotBlank(instanceUrl, nameof(instanceUrl));
            //Preconditions.CheckNotBlank(apiVersion, nameof(apiVersion));

            AccessToken = accessToken;
            InstanceUrl = instanceUrl;
            ApiVersion = apiVersion;
        }

        #region Public Methods
        /// <summary>
        /// Access token that acts as a session ID that the application uses for making requests.
        /// This token should be protected as though it were user credentials.
        /// </summary>
        public string AccessToken { get; private set; }
        /// <summary>
        /// Identifies the Salesforce instance to which API calls should be sent.
        /// </summary>
        public string InstanceUrl { get; private set; }
        /// <summary>
        /// Api Version.
        /// </summary>
        public string ApiVersion { get; private set; }
        #endregion
    }
}
