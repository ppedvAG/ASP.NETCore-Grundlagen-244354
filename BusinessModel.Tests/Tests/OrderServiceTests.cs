using BusinessLogic.Models.Enums;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private DeliveryDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new TestDatabase().Context;
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
        }

        [TestMethod]
        public async Task CurrentOrder_Existing_EnsureOrderExists()
        {
            // Arrange
            var orderService = new OrderService(_context);

            // Act
            var result = await orderService.CurrentOrder(Seed.DEFAULT_USER_NAME);

            // Assert
            Assert.IsNotNull(result, "Should return the existing order from seed.");
            Assert.AreEqual(Seed.DEFAULT_USER_NAME, result.UserName);
            Assert.AreEqual(OrderStatus.Pending, result.Status);

            Assert.IsNotNull(result.OrderItems, "Order items should be loaded.");
            Assert.IsTrue(result.OrderItems.Any(), "Should contain any order items.");

            var item = result.OrderItems.First();
            Assert.AreEqual(Seed.FIRST_ORDERITEM_RECIPE_ID, item.RecipeId);
            Assert.AreEqual(Seed.FIRST_ORDERITEM_QUANTITY, item.Quantity);
            Assert.IsNotNull(item.Recipe, "Recipe should be loaded.");
        }

        [TestMethod]
        [DataRow("Tessa Tester")]
        public async Task CurrentOrder_NewOrder_CreatesNewOrder(string userName)
        {
            // Arrange
            var orderService = new OrderService(_context);

            // Act
            var result = await orderService.CurrentOrder(userName);

            // Assert
            Assert.IsNotNull(result, "Should return the newly created order.");
            Assert.AreEqual(userName, result.UserName);
            Assert.AreEqual(OrderStatus.Pending, result.Status);
        }

        [TestMethod]
        [DataRow(Seed.DEFAULT_USER_NAME, 2, 3)]
        public async Task UpdateOrder_AddSingleOrder_CreatesSingleOrderItem(string userName, int recipeId, int quantity)
        {
            // Arrange
            var recipeService = new RecipeService(_context);
            var orderService = new OrderService(_context);

            // Act
            var recipe = await recipeService.GetById(recipeId);
            int orderItemId = await orderService.UpdateOrder(userName, recipe, quantity);

            var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == Seed.DEFAULT_ORDER_ID);

            // Assert
            Assert.IsNotNull(order, "Should return the existing order from seed.");

            var item = order.OrderItems.SingleOrDefault(o => o.Id == orderItemId);
            Assert.IsNotNull(item, $"Should have created new order item with id {orderItemId}.");
            Assert.IsNotNull(item.Recipe, "Recipe should be loaded.");
            Assert.AreEqual(recipeId, item.Recipe.Id);

        }

        [TestMethod]
        public async Task FinishOrder_ExistingOrder_SetsStatusDone()
        {
            // Arrange
            var orderService = new OrderService(_context);
            var order = await _context.Orders.SingleAsync(o => o.Id == Seed.DEFAULT_ORDER_ID);

            // Act
            bool done = await orderService.FinishOrder(Seed.DEFAULT_USER_NAME);

            // Assert
            Assert.IsTrue(done, "Order should be finished.");
            Assert.IsNotNull(order, "Should return the existing order from seed.");
            Assert.AreEqual(OrderStatus.Done, order.Status);
        }
    }
}
