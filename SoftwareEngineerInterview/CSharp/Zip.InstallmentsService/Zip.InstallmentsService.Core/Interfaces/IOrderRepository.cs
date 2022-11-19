using Zip.InstallmentsService.Core.Entity;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Guid> CreateOrder(double orderAmount);
        Task<Order> GetOrder(Guid orderId);
    }
}
