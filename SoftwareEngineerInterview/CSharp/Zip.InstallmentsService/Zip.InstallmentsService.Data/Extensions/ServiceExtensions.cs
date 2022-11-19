using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Data.Repositories;

namespace Zip.InstallmentsService.Data.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceCollectionExtensionsOfData(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase(databaseName: "ZipInstallmentsDb"));

            services.AddScoped<IOrderRepository, OrdersRepository>();
            services.AddScoped<IInstallmentsRepository, InstallmentsRepository>();

            return services;
        }
    }
}
