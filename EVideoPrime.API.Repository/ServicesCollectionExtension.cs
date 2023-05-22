using EVideoPrime.API.Repository.SqlRepository.Interface.Identity;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Services.Identity;
using EVideoPrime.API.Repository.SqlRepository.Services.VideoPrime;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Repository
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkIdentity, UnitOfWorkIdentity>();
            services.AddScoped<IUnitOfWorkVideoPrime, UnitOfWorkVideoPrime>();
            return services;
        }
    }
}
