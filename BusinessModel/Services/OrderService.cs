using BusinessLogic.Models.Enums;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services
{
    public class OrderService
    {
        private readonly DeliveryDbContext _context;

        public OrderService(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> CurrentOrder(string userName)
        {
            Order? order = await GetPendingOrderByUserName(userName);

            if (order == null)
            {
                order = new Order
                {
                    UserName = userName,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(order);

                await _context.SaveChangesAsync();
            }

            return order;
        }

        private async Task<Order?> GetPendingOrderByUserName(string userName)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Recipe)
                .FirstOrDefaultAsync(o => o.UserName == userName && o.Status == OrderStatus.Pending);
        }

        public async Task<bool> FinishOrder(string userName)
        {
            var order = await GetPendingOrderByUserName(userName);

            if (order != null)
            {
                order.Status = OrderStatus.Done;
                _context.Update(order);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> UpdateOrder(string userName, Recipe? recipe, int quantity)
        {
            var order = await GetPendingOrderByUserName(userName);
            var item = new OrderItem { Recipe = recipe, Quantity = quantity };
            if (order != null)
            {
                order.OrderItems.Add(item);

                await _context.SaveChangesAsync();
                return item.Id;
            }
            return 0;
        }
    }
}
