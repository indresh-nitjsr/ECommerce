using CoreLogic.Services;

namespace CoreTests
{
    public class OrderTests
    {
        OrderService orderService;


        [SetUp]
        public void Setup()
        {
            orderService = new OrderService();
        }

        [Test]
        public void GetOrderServiceAsExpected()
        {
            var result = orderService.GetAllOrders();
            var count = result.Count();
            Assert.IsTrue(count > 0);
        }
    }
}