﻿using APIdaze.SDK.Exception;

namespace APIdaze.SDK.Base
{
    /// <summary>
    ///     The credentials to use in authenticate in Apidaze REST API
    /// </summary>
    public class Credentials
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:plivo.Authentication.BasicAuth" /> class.
        /// </summary>
        /// <param name="apiKey">Auth identifier.</param>
        /// <param name="authToken">Auth token.</param>
        public Credentials(string apiKey, string apiSecret)
        {
            if (apiKey == null || apiSecret == null)
                throw new ApidazeCredentialsException("Authentication credentials not supplied");
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        /// <summary>
        ///     Gets or sets the authentication identifier.
        /// </summary>
        /// <value>The authentication identifier.</value>
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the authentication token.
        /// </summary>
        /// <value>The authentication token.</value>
        public string ApiSecret { get; set; }
    }
}