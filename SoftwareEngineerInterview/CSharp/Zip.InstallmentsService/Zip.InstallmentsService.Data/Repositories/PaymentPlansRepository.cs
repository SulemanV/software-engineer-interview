using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Data.Repositories
{
    public class PaymentPlansRepository: IPaymentPlansRepository
    {
        private readonly ILogger<PaymentPlansRepository> _logger;
        private readonly InMemoryDbContext _context;

        public PaymentPlansRepository(ILogger<PaymentPlansRepository> logger,
            InMemoryDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddPaymentPlan(PaymentPlan paymentPlan)
        {
            try
            {
                _context.PaymentPlans.Add(paymentPlan);
                _context.SaveChanges();
                return paymentPlan.Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public async Task<PaymentPlan> GetPaymentPlan(int paymentPlanId)
        {
            try
            {
                var query = _context.PaymentPlans.Where(p => p.Id == paymentPlanId)
                    .Include(p => p.Instalments);
                return query.SingleOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }
    }
}
