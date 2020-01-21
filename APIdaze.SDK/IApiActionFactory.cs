using APIdaze.SDK.Applications;
using APIdaze.SDK.Calls;
using APIdaze.SDK.CdrHttpHandlers;
using APIdaze.SDK.ExternalScripts;
using APIdaze.SDK.Validates;
using APIdaze.SDK.Messages;
using APIdaze.SDK.Recordings;

namespace APIdaze.SDK
{
    public interface IApiActionFactory
    {
        IMessage CreateMessageApi();

        ICredentialsValidator CreateCredentialsValidatorApi();

        ICalls CreateCallsApi();

        IApplications CreateApplicationsApi();

        ICdrHttpHandlers CreateCdrHttpHandlersApi();

        IRecordings CreateRecordingsApi();

        IExternalScripts CreateExternalScriptsApi();
    }
}