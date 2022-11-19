using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Core.Entity;
using Zip.InstallmentsService.Core.Interfaces;

namespace Zip.InstallmentsService.Data.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly ILogger<OrdersRepository> _logger;
        private readonly InMemoryContext _context;

        public OrdersRepository(ILogger<OrdersRepository> logger,
            InMemoryContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Guid> CreateOrder(double orderAmount)
        {
            var order = new Order
                {
                    OrderId = Guid.NewGuid(),
                    OrderAmount = orderAmount
                };
            _context.Orders.Add(order);

            _context.SaveChanges();

            return order.OrderId;
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return _context.Orders.Where(o => o.OrderId == orderId).SingleOrDefault();
        }
    }
}
