using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.Entity;
using Zip.InstallmentsService.Core.Interfaces;

namespace Zip.InstallmentsService.Data.Repositories
{
    public class InstallmentsRepository : IInstallmentsRepository
    {
        private readonly ILogger<InstallmentsRepository> _logger;
        private readonly InMemoryContext _context;

        public InstallmentsRepository(ILogger<InstallmentsRepository> logger,
            InMemoryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Guid>> AddOrderInstallments(List<Installment> installments)
        {
            installments.ForEach(i =>
            {
                i.InstallmentId = Guid.NewGuid();
            });
            _context.Installments.AddRange(installments);

            _context.SaveChanges();

            return installments.Select(x => x.InstallmentId).ToList();
        }

        public async Task<List<Installment>> GetInstallments(List<Guid> installmentIds)
        {
            var query = _context.Installments.Where(i => installmentIds.Contains(i.InstallmentId));

            return query.ToList();
        }
    }
}
