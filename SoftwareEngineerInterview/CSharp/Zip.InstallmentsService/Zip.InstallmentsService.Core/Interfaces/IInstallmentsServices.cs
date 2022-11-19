using Zip.InstallmentsService.Core.Entity;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IInstallmentsServices
    {
        Task<List<Installment>> GetOrderInstallments(CreateOrderModel orderModel);
    }
}
