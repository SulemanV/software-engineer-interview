using AutoMapper;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Services.MappingProfiles
{
    public class PaymentPlanMappingProfiles : Profile
    {
        public PaymentPlanMappingProfiles()
        {
            CreateMap<PaymentPlan, PaymentInstallmentsDto>()
                .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Instalment, InstallmentsDto>()
                .ForMember(dest => dest.InstalmentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
