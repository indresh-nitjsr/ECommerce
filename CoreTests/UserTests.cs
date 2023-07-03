using CoreLogic.Services;

namespace CoreTests
{
    public class UserTests
    {
        UserService userService;


        [SetUp]
        public void Setup()
        {
            userService = new UserService();
        }

        [Test]
        public void GetUserServiceAsExpected()
        {
            var result = userService.GetAllUsers();
            var count = result.Count();
            Assert.IsTrue(count>0);
            
        }
    }
}