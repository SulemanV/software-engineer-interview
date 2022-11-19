using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.MappingProfiles;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollectionExtensionsOfService(this IServiceCollection services)
        {// Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderMappingProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IInstallmentsServices, InstallmentsServices>();

            return services;
        }
    }
}
