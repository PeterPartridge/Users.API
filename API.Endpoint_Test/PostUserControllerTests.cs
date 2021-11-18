using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace API.EndPoint_Tests
{
    public class PostUserControllerTests : APITestBaseClass
    {
        public PostUserControllerTests(): base()
        {

        }
       
        [Fact]
        public async void UserControllerTests_PostNewListOfUsername_ReturnOKResult()
        {
            List<string> newUserNames=new List<string>() { "Krusty", "Homer", "Bart"};
            IActionResult UsersPutAction = await _userController.Post(newUserNames);
            OkObjectResult result = UsersPutAction as OkObjectResult;
            Assert.True(result.StatusCode == 200);
        }
        [Fact]
        public async void UserControllerTests_PostNullListOfUsername_ReturnBadResult()
        {
            IActionResult UsersPutAction = await _userController.Post(null);
            BadRequestObjectResult result = UsersPutAction as BadRequestObjectResult;
            Assert.True(result.StatusCode == 400);
        }
        [Fact]
        public async void UserControllerTests_PostNewListOfUsernameWithEmpty_ReturnBadResult()
        {
            List<string> newUserNames = new List<string>() { "Marge", "Side Show bob", null };
            IActionResult UsersPutAction = await _userController.Post(newUserNames);
            BadRequestObjectResult result = UsersPutAction as BadRequestObjectResult;
            Assert.True(result.StatusCode == 400);
        }
    }
}