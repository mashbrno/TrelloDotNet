﻿using System.Security;
using System.Threading;
using System.Threading.Tasks;
using TrelloDotNet.Model;

namespace TrelloDotNet
{
    public partial class TrelloClient
    {
        /// <summary>
        /// Get an Organization (also known as Workspace)
        /// </summary>
        /// <param name="organizationId">ID of an Organization</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>The Organization</returns>
        public async Task<Organization> GetOrganizationAsync(string organizationId, CancellationToken cancellationToken = default)
        {
            return await _apiRequestController.Get<Organization>($"{UrlPaths.Organizations}/{organizationId}", cancellationToken);
        }

        /// <summary>
        /// Create a new Organization (Workspace)
        /// </summary>
        /// <param name="newOrganization">the new Organization</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>The New Organization</returns>
        public async Task<Organization> AddOrganizationAsync(Organization newOrganization, CancellationToken cancellationToken = default)
        {
            return await _apiRequestController.Post<Organization>($"{UrlPaths.Organizations}", cancellationToken, _queryParametersBuilder.GetViaQueryParameterAttributes(newOrganization));
        }

        /// <summary>
        /// Update an Organization (Workspace)
        /// </summary>
        /// <param name="organizationWithChanges">Organization with changes</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>The updated Organization</returns>
        public async Task<Organization> UpdateOrganizationAsync(Organization organizationWithChanges, CancellationToken cancellationToken = default)
        {
            return await _apiRequestController.Put<Organization>($"{UrlPaths.Organizations}/{organizationWithChanges.Id}", cancellationToken, _queryParametersBuilder.GetViaQueryParameterAttributes(organizationWithChanges));
        }

        /// <summary>
        /// Delete a entire Organization include all Boards it contains (WARNING: THERE IS NO WAY GOING BACK!!!).
        /// </summary>
        /// <remarks>
        /// As this is a major thing, there is a secondary confirm needed by setting: Options.AllowDeleteOfOrganizations = true
        /// </remarks>
        /// <param name="organizationId">The id of the Organization to Delete</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        public async Task DeleteOrganizationAsync(string organizationId, CancellationToken cancellationToken = default)
        {
            if (Options.AllowDeleteOfOrganizations)
            {
                await _apiRequestController.Delete($"{UrlPaths.Organizations}/{organizationId}", cancellationToken);
            }
            else
            {
                throw new SecurityException(@"Deletion of Organizations are disabled via Options.AllowDeleteOfOrganizations (You need to enable this as a secondary confirmation that you REALLY wish to use that option as there is no going back)");
            }
        }
    }
}