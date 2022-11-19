using Zip.InstallmentsService.Core.Entity;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IInstallmentsRepository
    {
        Task<List<Guid>> AddOrderInstallments(List<Installment> installments);
        Task<List<Installment>> GetInstallments(List<Guid> installmentIds);
    }
}
