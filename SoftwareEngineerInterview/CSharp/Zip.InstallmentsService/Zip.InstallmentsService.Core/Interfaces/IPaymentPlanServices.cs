using Zip.InstallmentsService.Core.ControllerModels;
using Zip.InstallmentsService.Core.Dto;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IPaymentPlanServices
    {
        Task<PaymentInstallmentsDto> AddPaymentPlan(CreatePaymentPlanCommand command);
    }
}
