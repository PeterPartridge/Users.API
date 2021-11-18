using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.EndPoint_Tests
{
    public class DeleteUserControllerTests : APITestBaseClass
    {
        public DeleteUserControllerTests(): base()
        {

        }
       
        [Fact]
        public async void UserControllerTests_DeleteUserWithIdOfOne_ReturnOKResult()
        {

            IActionResult UsersGetAction = await _userController.Delete(1);
            OkResult result = UsersGetAction as OkResult;
            Assert.True(result.StatusCode == 200);
        }
        [Fact]
        public async void UserControllerTests_DeleteUserWithIdOfMinusOne_ReturnBadResultResult()
        {
            IActionResult UsersGetAction = await _userController.Delete(-1);
            BadRequestObjectResult result = UsersGetAction as BadRequestObjectResult;
            Assert.True(result.StatusCode == 400);
        }
    }
}