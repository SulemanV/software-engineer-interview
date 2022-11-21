using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Services.Services;

namespace Zip.InstallmentsService.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollectionsOfService(this IServiceCollection services)
        {

            services.AddAutoMapper(cfg => { cfg.AllowNullCollections = true; }, Assembly.GetExecutingAssembly());

            services.AddScoped<IPaymentPlanServices, PaymentPlanServices>();

            return services;
        }
    }
}
