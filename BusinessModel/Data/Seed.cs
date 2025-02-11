using BusinessLogic.Models.Enums;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data
{
    public class Seed
    {
        public const int OrderIdOne = 1;

        public static void SeedData(ModelBuilder modelBuilder) 
        {
            var recipes = RecipeReader.FromJsonFile();

            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    RecipeId = 1,
                    OrderId = 1,
                    Quantity = 2,
                    Rating = 5
                },
                new OrderItem
                {
                    Id = 2,
                    RecipeId = 3,
                    OrderId = 1,
                    Quantity = 1,
                    Rating = 8.2f
                },
            };

            var orders = new List<Order>
            {
                new Order
                {
                    Id = OrderIdOne,
                    UserName = "John Doe",
                    OrderDate = DateTime.Now,
                    Rating = 6.8f,
                    Status = OrderStatus.Pending
                }
            };

            modelBuilder.Entity<Recipe>().HasData(recipes);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderItem>().HasData(orderItems);

        }
    }
}
