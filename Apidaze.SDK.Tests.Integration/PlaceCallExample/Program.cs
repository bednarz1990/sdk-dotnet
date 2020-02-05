using APIdaze.SDK;
using APIdaze.SDK.Base;
using APIdaze.SDK.Exception;
using APIdaze.SDK.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using CallType = APIdaze.SDK.Calls.CallType;

namespace PlaceCallExample
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var config = BuildConfig();

            var apiKey = config["API_KEY"];
            var apiSecret = config["API_SECRET"];

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                Console.WriteLine("System environment variables API_KEY and API_SECRET must be set.");
                Environment.Exit(0);
            }

            // initiate ApplicationAction
            var applicationClient = ApplicationManager.CreateApiFactory(new Credentials(apiKey, apiSecret));

            // call details
            var callerId = "14123456789";
            var origin = "48123456789";
            var destination = "48123456789";

            try
            {
                //initialize callsApi
                var callsApi = applicationClient.CreateCallsApi();

                //make a call
                callsApi.CreateCall(new PhoneNumber(callerId), origin, destination, CallType.NUMBER);

                Console.WriteLine("Call with id = {0} has been initiated.", callsApi);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("An error occurred during communicating with API", e);
            }
            catch (CreateCallResponseException e)
            {
                Console.WriteLine("Placing the call failed due to [{0}].", e.Message);
            }
            catch (InvalidPhoneNumberException e)
            {
                Console.WriteLine("Phone number {0} is invalid", e.Message);
            }
        }

        /// <summary>
        /// Builds the configuration.
        /// </summary>
        /// <returns>IConfigurationRoot.</returns>
        private static IConfigurationRoot BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("client-secrets.json", optional: true, reloadOnChange: true).Build();
        }
    }
}