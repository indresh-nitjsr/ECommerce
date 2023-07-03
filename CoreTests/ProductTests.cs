using CoreLogic.Services;

namespace CoreTests
{
    public class ProductTests
    {
        ProductService productService;


        [SetUp]
        public void Setup()
        {
            productService = new ProductService();
        }

        [Test]
        public void GetProductServiceAsExpected()
        {
            var result = productService.GetAllProducts();
            var count = result.Count();
            Assert.IsTrue(count > 0);

        }
    }
}