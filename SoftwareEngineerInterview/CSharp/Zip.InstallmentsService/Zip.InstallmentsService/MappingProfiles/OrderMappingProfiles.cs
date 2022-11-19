using AutoMapper;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Entity;

namespace Zip.InstallmentsService.MappingProfiles
{
    public class OrderMappingProfiles: Profile
    {
        public OrderMappingProfiles()
        {
            CreateMap<Order, CreateOrderDto>();
            CreateMap<Installment, CreateOrderInstallmentsDto>();
        }
    }
}
