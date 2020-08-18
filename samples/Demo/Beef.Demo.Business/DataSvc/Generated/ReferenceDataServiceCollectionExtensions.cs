/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using Microsoft.Extensions.DependencyInjection;

namespace Beef.Demo.Business.DataSvc
{
    /// <summary>
    /// Provides the generated <b>DataSvc</b>-layer services.
    /// </summary>
    public static class ReferenceDataServiceCollectionsExtension
    {
        /// <summary>
        /// Adds the generated <b>DataSvc</b>-layer services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddGeneratedReferenceDataDataSvcServices(this IServiceCollection services)
        {
            return services.AddSingleton<IReferenceDataDataSvc, ReferenceDataDataSvc>()
                           .AddScoped<IGenderDataSvc, GenderDataSvc>();
        }
    }
}

#pragma warning restore IDE0005
#nullable restore