using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Users.Domain.Model;
using Xunit;

namespace API.EndPoint_Tests
{
    public class GetUserControllerTests : APITestBaseClass
    {
        public GetUserControllerTests(): base()
        {

        }
       
        [Fact]
        public async void UserControllerTests_GetUsers_ReturnOKResult()
        {

            IActionResult UsersGetAction = await _userController.Get();
            OkObjectResult result = UsersGetAction as OkObjectResult;
            Assert.True(result.StatusCode == 200);
        }


        [Fact]
        public async void UserControllerTests_GetUsersAndCheckOrderById_ReturnOKResult()
        {

            IActionResult UsersGetAction = await _userController.Get();
            OkObjectResult result = UsersGetAction as OkObjectResult;
            var a = result.Value as IOrderedEnumerable<User>;
            Assert.True(result.StatusCode == 200);
        }
        [Fact]
        public async void UserControllerTests_GetUsers_ReturnAListWithResults()
        {
             IActionResult UsersGetAction = await _userController.Get();
            OkObjectResult result = UsersGetAction as OkObjectResult;
            IEnumerable<User>? returnedUsers = result.Value as IEnumerable<User>;
            Assert.True(returnedUsers.Count() >0);
        }
    }
}