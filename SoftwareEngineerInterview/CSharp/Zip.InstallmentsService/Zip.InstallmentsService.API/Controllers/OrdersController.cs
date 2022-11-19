using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Core.Dto;
using Zip.InstallmentsService.Core.Interfaces;
using Zip.InstallmentsService.Core.Models;

namespace Zip.InstallmentsService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderServices _orderServices;

        public OrdersController(ILogger<OrdersController> logger,
            IOrderServices orderServices)
        {
            _logger = logger;
            _orderServices = orderServices;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderDto>> CreateOrder([FromBody] CreateOrderModel order)
        {
            var _result = await _orderServices.CreateOrder(order);
            if(_result != null)
            {
                return Ok(_result);
            }

            return BadRequest();
        }
    }
}
