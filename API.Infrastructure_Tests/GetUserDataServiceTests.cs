using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Model;
using Xunit;

namespace API.Infrastructure_Tests
{
    public class GetUserDataServiceTests : InfrastructureTestBaseClass
    {


        public GetUserDataServiceTests() : base()
        {
            
        }

        [Fact]
        public async Task UserDataServiceTests_GetUsers_ReturnTrue()
        {
            IList<User> SeededUsers = await _userDataService.GetUsersAsync();
            Assert.True(SeededUsers.Count >0);
        }

        [Fact]
        public async Task UserDataServiceTests_GetUserWithIdOfOne_ReturnTrue()
        {
            User SeededUser = await _userDataService.GetUserByIdAsync(3);
            Assert.True( SeededUser.UserId == 3);
        }

        [Fact]
        public async Task UserDataServiceTests_GetUserWithIdOfOneHundred_ReturnsNULL()
        {
            User NullUser = await _userDataService.GetUserByIdAsync(100);
            Assert.True(NullUser == null);
        }

        
    }
}