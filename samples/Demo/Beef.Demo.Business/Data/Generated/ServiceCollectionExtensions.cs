/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using Microsoft.Extensions.DependencyInjection;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the generated <b>Data</b>-layer services.
    /// </summary>
    public static class ServiceCollectionsExtension
    {
        /// <summary>
        /// Adds the generated <b>Data</b>-layer services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddGeneratedDataServices(this IServiceCollection services)
        {
            return services.AddScoped<IPersonData, PersonData>()
                           .AddScoped<IProductData, ProductData>()
                           .AddScoped<IRobotData, RobotData>()
                           .AddScoped<ITripPersonData, TripPersonData>()
                           .AddScoped<IContactData, ContactData>();
        }
    }
}

#pragma warning restore IDE0005
#nullable restore