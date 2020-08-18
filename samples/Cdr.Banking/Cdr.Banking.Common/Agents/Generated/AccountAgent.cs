/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Common.Agents
{
    /// <summary>
    /// Defines the Account Web API agent.
    /// </summary>
    public partial interface IAccountAgent
    {
        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <param name="args">The Args (see <see cref="AccountArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<AccountCollectionResult>> GetAccountsAsync(AccountArgs? args, PagingArgs? paging = null, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Get <see cref="AccountDetail"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<AccountDetail>> GetDetailAsync(string? accountId, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Get <see cref="Account"/> <see cref="Balance"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<Balance>> GetBalanceAsync(string? accountId, WebApiRequestOptions? requestOptions = null);
    }

    /// <summary>
    /// Provides the Account Web API agent.
    /// </summary>
    public partial class AccountAgent : WebApiAgentBase, IAccountAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAgent"/> class.
        /// </summary>
        /// <param name="args">The <see cref="IWebApiAgentArgs"/>.</param>
        public AccountAgent(IWebApiAgentArgs args) : base(args) { }

        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <param name="args">The Args (see <see cref="AccountArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<AccountCollectionResult>> GetAccountsAsync(AccountArgs? args, PagingArgs? paging = null, WebApiRequestOptions? requestOptions = null)
        {
            return GetCollectionResultAsync<AccountCollectionResult, AccountCollection, Account>("api/v1/banking/accounts", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<AccountArgs?>("args", args, WebApiArgType.FromUriUseProperties), new WebApiPagingArgsArg("paging", paging) });
        }

        /// <summary>
        /// Get <see cref="AccountDetail"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<AccountDetail>> GetDetailAsync(string? accountId, WebApiRequestOptions? requestOptions = null)
        {
            return GetAsync<AccountDetail>("api/v1/banking/accounts/{accountId}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("accountId", accountId) });
        }

        /// <summary>
        /// Get <see cref="Account"/> <see cref="Balance"/>.
        /// </summary>
        /// <param name="accountId">The <see cref="Account"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Balance>> GetBalanceAsync(string? accountId, WebApiRequestOptions? requestOptions = null)
        {
            return GetAsync<Balance>("api/v1/banking/accounts/{accountId}/balance", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string?>("accountId", accountId) });
        }
    }
}

#pragma warning restore IDE0005
#nullable restore