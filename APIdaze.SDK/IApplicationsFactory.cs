using APIdaze.SDK.Applications;

namespace APIdaze.SDK
{
    /// <summary>
    /// Interface IApplicationsFactory
    /// </summary>
    public interface IApplicationsFactory
    {
        /// <summary>
        /// Creates the applications API.
        /// </summary>
        /// <returns>IApplications.</returns>
        IApplications CreateApplicationsApi();
    }
}