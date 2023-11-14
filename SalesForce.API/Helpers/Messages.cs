using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForce.API.Helpers
{
    public static class Messages
    {
        /// <summary>
        /// Exception message when access token is missing.
        /// </summary>
        public const string ACCESS_TOKEN_MISSING = "Access token must not be empty or consist of whitespaces";
        /// <summary>
        /// Exception message when instance url is missing.
        /// </summary>
        public const string INSTANCE_URL_MISSING = "Instance url must not be empty or consist of whitespaces.";
        /// <summary>
        /// Exception message when api version is missing.
        /// </summary>
        public const string API_VERSION_MISSING = "Api Version must not be empty or consist of whitespaces.";
    }
}