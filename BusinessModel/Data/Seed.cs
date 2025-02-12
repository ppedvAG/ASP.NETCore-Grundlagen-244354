using BusinessLogic.Models.Enums;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data
{
    public class Seed
    {
        public const int DEFAULT_ORDER_ID = 1;
        public const int DEFAULT_RECIPE_ID = 1;
        public const int FIRST_ORDERITEM_RECIPE_ID = DEFAULT_RECIPE_ID;
        public const int FIRST_ORDERITEM_QUANTITY = 2;
        public const int FIRST_ORDERITEM_RATING = 5;
        public const string DEFAULT_USER_NAME = "John Doe";

        public static void SeedData(ModelBuilder modelBuilder) 
        {
            var recipes = RecipeReader.FromJsonFile();

            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    RecipeId = FIRST_ORDERITEM_RECIPE_ID,
                    OrderId = 1,
                    Quantity = FIRST_ORDERITEM_QUANTITY,
                    Rating = FIRST_ORDERITEM_RATING
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
                    Id = DEFAULT_ORDER_ID,
                    UserName = DEFAULT_USER_NAME,
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
