using System;
using Assecor.Core.Persons;
using Assecor.EF.Mappings;
using Assecor.EF.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assecor.EF
{
    public static class AssecorEfServiceExtension
    {
        /// <summary>
        ///     Registers <see cref="PersonService" />,
        ///     Adds AutoMapper and <see cref="AssecorEfMappingProfile" />,
        ///     Adds <see cref="AssecorDbContext" />
        /// </summary>
        public static IServiceCollection AddEfServices(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dboptions)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(c => c.AddProfile(new AssecorEfMappingProfile()));
            services.AddDbContext<AssecorDbContext>(dboptions);

            return services;
        }
    }
}