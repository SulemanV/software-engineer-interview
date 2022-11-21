using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Zip.InstallmentsService.Core.ControllerModels;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;
using Zip.InstallmentsService.Services.Services;

namespace Zip.InstallmentsService.Tests
{
    public class PaymentPlanServicesTests
    {
        private readonly PaymentPlanServices _paymentPlanServices;
        private readonly Mock<ILogger<PaymentPlanServices>> _mockLogger = new Mock<ILogger<PaymentPlanServices>>();
        private readonly Mock<IPaymentPlansRepository> _mockPaymentPlanRepository = new Mock<IPaymentPlansRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        public PaymentPlanServicesTests()
        {
            _paymentPlanServices = new PaymentPlanServices(_mockLogger.Object,
                _mockPaymentPlanRepository.Object,
                _mockMapper.Object);
        }

        [Fact]
        public async void AddPaymentPlan_ValidData()
        {
            // arrange
            CreatePaymentPlanCommand command = new CreatePaymentPlanCommand
            {
                Amount = 100,
                Frequency = 14,
                NumberOfInstallments = 4,
                UserId = 1
            };
            var paymentPlanId = 1;
            PaymentPlan paymentPlan = new PaymentPlan
            {
                Id = paymentPlanId,
                PurchaseAmount = 100,
                UserId = 1,
                Instalments = new List<Instalment>
                {
                    new Instalment
                    {
                        Id = 1,
                        Amount = 25,
                        DueDate = DateTime.Today
                    },
                    new Instalment
                    {
                        Id = 2,
                        Amount = 25,
                        DueDate = DateTime.Today.AddDays(14)
                    },
                    new Instalment
                    {
                        Id = 3,
                        Amount = 25,
                        DueDate = DateTime.Today.AddDays(14 * 2)
                    },
                    new Instalment
                    {
                        Id = 4,
                        Amount = 25,
                        DueDate = DateTime.Today.AddDays(14 * 3)
                    }
                }
            };

            PaymentInstallmentsDto expectedResult = new PaymentInstallmentsDto
            {
                UserId = 1,
                PuchaseAmount = 100,
                PaymentId = paymentPlanId,
                NumberOfInstalments = 4,
                Instalments = new List<InstallmentsDto>
                {
                    new InstallmentsDto
                    {
                        InstalmentId = 1,
                        DueDate = DateTime.Today,
                        Amount = 25
                    },
                    new InstallmentsDto
                    {
                        InstalmentId = 2,
                        DueDate = DateTime.Today.AddDays(14),
                        Amount = 25
                    },
                    new InstallmentsDto
                    {
                        InstalmentId = 3,
                        DueDate = DateTime.Today.AddDays(14 * 2),
                        Amount = 25
                    },
                    new InstallmentsDto
                    {
                        InstalmentId = 4,
                        DueDate = DateTime.Today.AddDays(14 * 3),
                        Amount = 25
                    }
                }
            };

            _mockPaymentPlanRepository.Setup(p => p.AddPaymentPlan(It.IsAny<PaymentPlan>())).ReturnsAsync(paymentPlanId);
            _mockPaymentPlanRepository.Setup(p => p.GetPaymentPlan(paymentPlanId)).ReturnsAsync(paymentPlan);
            _mockMapper.Setup(x => x.Map<PaymentInstallmentsDto>(It.IsAny<PaymentPlan>())).Returns(expectedResult);

            // act
            var actualResult = await _paymentPlanServices.AddPaymentPlan(command);

            // assert
            Assert.Equal(expectedResult, actualResult);
            _mockPaymentPlanRepository.Verify(p => p.AddPaymentPlan(It.IsAny<PaymentPlan>()), Times.Once);
            _mockPaymentPlanRepository.Verify(p => p.GetPaymentPlan(paymentPlanId), Times.Once);
            _mockMapper.Verify(x => x.Map<PaymentInstallmentsDto>(It.IsAny<PaymentPlan>()), Times.Once);
        }
    }
}
