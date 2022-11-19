using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.Entity;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Services
{
    public class InstallmentsServices : IInstallmentsServices
    {
        private readonly ILogger<InstallmentsServices> _logger;
        private readonly IInstallmentsRepository _installmentsRepository;

        public InstallmentsServices(ILogger<InstallmentsServices> logger,
            IOrderRepository orderRepository,
            IInstallmentsRepository installmentsRepository)
        {
            _logger = logger;
            _installmentsRepository = installmentsRepository;
        }

        public async Task<List<Installment>> GetOrderInstallments(CreateOrderModel orderModel)
        {
            List<Installment> installments = new List<Installment>();
            try
            {
                var amount = orderModel.Amount / orderModel.NumberOfInstallments;
                for (int i = 0; i < orderModel.NumberOfInstallments; i++)
                {
                    var installment = new Installment
                    {
                        InstallmentAmount = amount,
                        DueDate = DateTime.Today.AddDays(i * orderModel.FrequencyDays)
                    };

                    installments.Add(installment);
                }

                return installments;
            }
            catch (Exception e)
            {
                _logger.LogError($"Class: InstallmentsServices; Method: AddOrderInstallments; Error{e.Message}");
                throw;
            }
        }
    }
}
