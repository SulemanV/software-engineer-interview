using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Data.Repositories;

namespace Zip.InstallmentsService.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollectionsOfData(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase(databaseName: "ZipInstallmentsDb"));

            services.AddScoped<IPaymentPlansRepository, PaymentPlansRepository>();

            return services;
        }
    }
}
