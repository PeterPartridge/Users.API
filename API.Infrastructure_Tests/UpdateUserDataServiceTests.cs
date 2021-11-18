using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Users.Domain.Model;
using Users.Infrastructure;
using Xunit;

namespace API.Infrastructure_Tests
{
    public class UpdateUserDataServiceTests : InfrastructureTestBaseClass
    {
        public UpdateUserDataServiceTests() : base()
        {

        }

        [Fact]
        public async Task UserDataServiceTests_UpdateUserWithIdOfOne_ReturnFalse()
        {
           
            User UserToEdit = await _userDataService.GetUserByIdAsync(2);
            UserToEdit.Username = "Test";
            User Updateduser = await _userDataService.UpdateUserAsync(UserToEdit);
            Assert.True(Updateduser.Username == "Test");
        }
        
        [Fact]
        public async Task UserDataServiceTests_UpdateUserWithNullObject_ReturnFalse()
        {
            SeedData.SeedUsers(_serviceProvider.GetService<UserDataContext>());
            User Updateduser = await _userDataService.UpdateUserAsync(null);
            Assert.True(Updateduser == null);
        }

    }
}
