﻿using APIdaze.SDK.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIdaze.SDK.Applications
{
    public class Applications : BaseApiClient, IApplications
    {
        protected override string Resource => "/applications";

        public Applications(IRestClient client, Credentials credentials) : base(client, credentials)
        {
        }

        public List<Application> GetApplications()
        {
            return FindAll<Application>().ToList();
        }

        public List<Application> GetApplicationsByApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("apiKey must not be null");
            }
            return FindByParameter<Application>("api_key", apiKey).ToList();
        }

        public List<Application> GetApplicationsById(long id)
        {
            return FindByParameter<Application>("api_id", id.ToString()).ToList();
        }

        public List<Application> GetApplicationsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("apiKey must not be null");
            }
            return FindByParameter<Application>("api_name", name).ToList();
        }
    }
}