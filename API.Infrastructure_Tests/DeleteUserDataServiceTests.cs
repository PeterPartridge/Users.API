using System.Threading.Tasks;
using Users.Domain.Model;
using Xunit;

namespace API.Infrastructure_Tests
{
    public class DeleteUserDataServiceTests : InfrastructureTestBaseClass
    {
        public DeleteUserDataServiceTests() : base()
        {

        }
        [Fact]
        public async Task UserDataServiceTests_DeleteUserWithIdOfOne_ReturnTrue()
        {
          User UserToDelete = await _userDataService.GetUserByIdAsync(1);
           bool DeletedUser = await _userDataService.DeleteUserAsync(UserToDelete);
            Assert.True(DeletedUser);
        }

        [Fact]
        public async Task UserDataServiceTests_DeleteUserWithIdOfFifty_ReturnFalse()
        {
            User UserToDelete = new User() { UserId = 50, Username = "Test" };
            bool DeletedUser = await _userDataService.DeleteUserAsync(UserToDelete);
            Assert.False(DeletedUser);
        }


        [Fact]
        public async Task UserDataServiceTests_DeleteUserWithNullObject_ReturnFalse()
        {
            bool DeletedUser = await _userDataService.DeleteUserAsync(null);
            Assert.False(DeletedUser);
        }
    }
}
