using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.EndPoint_Tests
{
    public class PutUserControllerTests : APITestBaseClass
    {
        public PutUserControllerTests(): base()
        {

        }
       
        [Fact]
        public async void UserControllerTests_PutUserWithNewName_ReturnOKResult()
        {

            IActionResult UsersPutAction = await _userController.Put(2,"Test");
            OkObjectResult result = UsersPutAction as OkObjectResult;
            Assert.True(result.StatusCode == 200);
        }
        [Fact]
        public async void UserControllerTests_PutUserWithIdofOneThousandAndNewName_ReturnBadResult()
        {

            IActionResult UsersPutAction = await _userController.Put(10000, "Test");
            BadRequestObjectResult result = UsersPutAction as BadRequestObjectResult;
            Assert.True(result.StatusCode == 400);
        }
        [Fact]
        public async void UserControllerTests_PutUserWithIdOfOneAndNullString_ReturnBadResultResults()
        {
            IActionResult UsersPutAction = await _userController.Put(1, null);
            BadRequestObjectResult result = UsersPutAction as BadRequestObjectResult;
            Assert.True(result.StatusCode == 400);
        }
    }
}