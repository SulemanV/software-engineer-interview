using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Data
{
    public class InMemoryDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ZipInstallmentsDb");
        }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options): base(options)
        {

        }

        public DbSet<PaymentPlan> PaymentPlans { get; set; }
        public DbSet<Instalment> Installments { get; set; }
    }
}
