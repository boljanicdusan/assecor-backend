using System;
using Assecor.Core.Persons;
using Assecor.CSV.Mappings;
using Assecor.CSV.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assecor.CSV
{
    public static class AssecorCsvServiceExtension
    {
        /// <summary>
        ///     Registers <see cref="PersonService" />,
        ///     Adds AutoMapper and <see cref="AssecorCsvMappingProfile" />,
        ///     Binds "FileConnections" section from appsettings.json to the <see cref="FileConnectionsConfiguration" /> class
        /// </summary>
        public static IServiceCollection AddCsvServices(
            this IServiceCollection services,
            IConfiguration configuration 
        )
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(c => c.AddProfile(new AssecorCsvMappingProfile()));

            // Bind FileConnections from appsettings.json to FileConnectionsConfiguration class
            var fileConnectionsConfig = new FileConnectionsConfiguration();
            configuration.Bind("FileConnections", fileConnectionsConfig);
            services.AddSingleton(fileConnectionsConfig);
            
            return services;
        }
    }
}