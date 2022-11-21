using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Core.ControllerModels;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Interfaces;

namespace Zip.InstalmentsService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentPlanController : ControllerBase
    {
        private readonly ILogger<PaymentPlanController> _logger;
        private readonly IPaymentPlanServices _paymentPlanServices;

        public PaymentPlanController(ILogger<PaymentPlanController> logger,
            IPaymentPlanServices paymentPlanServices)
        {
            _logger = logger;
            _paymentPlanServices = paymentPlanServices;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentInstallmentsDto>> PaymentPlanInfo([FromBody] CreatePaymentPlanCommand command)
        {
            _logger.LogInformation("Getting Paymnet Plan Info");
            return Ok(await _paymentPlanServices.AddPaymentPlan(command));
        }
    }
}
