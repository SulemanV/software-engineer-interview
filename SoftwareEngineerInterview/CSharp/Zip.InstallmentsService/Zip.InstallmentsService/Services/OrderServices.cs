using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ILogger<OrderServices> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IInstallmentsServices _installmentsServices;
        private readonly IInstallmentsRepository _installmentsRepository;

        public OrderServices(ILogger<OrderServices> logger,
            IMapper mapper,
            IOrderRepository orderRepository,
            IInstallmentsServices installmentsServices,
            IInstallmentsRepository installmentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _installmentsServices = installmentsServices;
            _installmentsRepository = installmentsRepository;
        }

        public async Task<CreateOrderDto> CreateOrder(CreateOrderModel orderModel)
        {
            try
            {
                var orderId = await _orderRepository.CreateOrder(orderModel.Amount);

                var installments = await _installmentsServices.GetOrderInstallments(orderModel);

                installments.ForEach(i =>
                {
                    i.OrderId = orderId;
                });

                var installmentIds = await _installmentsRepository.AddOrderInstallments(installments);

                var order = await _orderRepository.GetOrder(orderId);
                var installmentsFromDb = await _installmentsRepository.GetInstallments(installmentIds);

                CreateOrderDto createOrderDto = new CreateOrderDto();
                createOrderDto = _mapper.Map<CreateOrderDto>(order);
                createOrderDto.Installments = _mapper.Map<List<CreateOrderInstallmentsDto>>(installmentsFromDb);
                createOrderDto.NumberOfInstallments = createOrderDto.Installments?.Count ?? 0;

                return createOrderDto;
            }
            catch (Exception e)
            {
                _logger.LogError($"Class: OrderServices; Method: CreateOrder; Error{e.Message}");
                throw;
            }
        }
    }
}
