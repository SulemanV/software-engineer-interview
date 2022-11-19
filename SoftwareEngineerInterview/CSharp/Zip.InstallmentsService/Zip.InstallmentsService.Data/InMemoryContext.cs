using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Core.Entity;

namespace Zip.InstallmentsService.Data
{
    public class InMemoryContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ZipInstallmentsDb");
        }

        public InMemoryContext(DbContextOptions<InMemoryContext> options)
        : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Installment> Installments { get; set; }
    }
}
