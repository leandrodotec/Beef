/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.Demo.Business;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Api.Controllers
{
    /// <summary>
    /// Provides the <b>Config</b> Web API functionality.
    /// </summary>
    [Route("api/v1/envvars")]
    public partial class ConfigController : ControllerBase
    {
        private readonly IConfigManager _manager;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IConfigManager"/>.</param>
        public ConfigController(IConfigManager manager) => _manager = Check.NotNull(manager, nameof(manager));

        /// <summary>
        /// Get Env Vars.
        /// </summary>
        /// <returns>A resultant <see cref="System.Collections.IDictionary"/>.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(System.Collections.IDictionary), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetEnvVars()
        {
            return new WebApiPost<System.Collections.IDictionary>(this, () => _manager.GetEnvVarsAsync(),
                operationType: OperationType.Unspecified, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }
    }
}

#pragma warning restore IDE0005
#nullable restore