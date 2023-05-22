using EVideoPrime.API.BusinessAccessLayer.Services.Identity;
using EVideoPrime.API.BusinessAccessLayer.Interface.Identity;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime;
using Microsoft.Extensions.DependencyInjection;

namespace EVideoPrime.API.BusinessAccessLayer
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleServices, RoleServices>();


            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ILanguageServices, LanguageServices>();
            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IPlanServices, PlanServices>();
            services.AddScoped<ISubscriptionServices, SubscriptionServices>();
            return services;
        }
    }
}
