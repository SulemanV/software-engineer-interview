using AutoMapper;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.ControllerModels;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Services.Services
{
    public class PaymentPlanServices : IPaymentPlanServices
    {
        private readonly ILogger<PaymentPlanServices> _logger;
        private readonly IPaymentPlansRepository _paymentPlansRepository;
        private readonly IMapper _mapper;

        public PaymentPlanServices(ILogger<PaymentPlanServices> logger,
            IPaymentPlansRepository paymentPlansRepository,
            IMapper mapper)
        {
            _logger = logger;
            _paymentPlansRepository = paymentPlansRepository;
            _mapper = mapper;
        }

        public async Task<PaymentInstallmentsDto> AddPaymentPlan(CreatePaymentPlanCommand command)
        {
            try
            {
                var paymentPlan = new PaymentPlan
                {
                    UserId = command.UserId,
                    PurchaseAmount = command.Amount
                };

                paymentPlan.Instalments = await GetPaymentInstallments(command.Amount, command.Frequency, command.NumberOfInstallments);

                var paymentPlanId = await _paymentPlansRepository.AddPaymentPlan(paymentPlan);
                paymentPlan = await _paymentPlansRepository.GetPaymentPlan(paymentPlanId);

                PaymentInstallmentsDto paymentInstallmentsDto = new PaymentInstallmentsDto();
                paymentInstallmentsDto = _mapper.Map<PaymentInstallmentsDto>(paymentPlan);

                return paymentInstallmentsDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public async Task<List<Instalment>> GetPaymentInstallments(decimal amount, int frequency, int numberOfInstallments)
        {
            try
            {
                List<Instalment> installments = new List<Instalment>();
                var installmentAmount = amount / numberOfInstallments;
                for (int i = 0; i < numberOfInstallments; i++)
                {
                    var installment = new Instalment
                    {
                        Amount = installmentAmount,
                        DueDate = DateTime.Today.AddDays(i * frequency)
                    };

                    installments.Add(installment);
                }

                return installments;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }
    }
}
