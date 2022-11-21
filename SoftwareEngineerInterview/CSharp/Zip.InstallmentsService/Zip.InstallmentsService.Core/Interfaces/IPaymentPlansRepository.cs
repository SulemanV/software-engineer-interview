using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IPaymentPlansRepository
    {
        Task<int> AddPaymentPlan(PaymentPlan paymentPlan);
        Task<PaymentPlan> GetPaymentPlan(int paymentPlanId);
    }
}
