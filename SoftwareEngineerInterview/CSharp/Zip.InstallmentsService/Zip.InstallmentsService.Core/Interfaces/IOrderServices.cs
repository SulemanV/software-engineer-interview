using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Core.Interfaces
{
    public interface IOrderServices
    {
        Task<CreateOrderDto> CreateOrder(CreateOrderModel order);
    }
}
