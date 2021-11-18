using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Model;
using Xunit;

namespace API.Infrastructure_Tests
{
    public class CreateUserDataServiceTests : InfrastructureTestBaseClass
    {
        public CreateUserDataServiceTests() : base()
        {

        }
        [Fact]
        public async Task UserDataServiceTests_CreateUsers_ReturnAllUsersWithId()
        {

            List<User> NewUsers = new()
            {
                new User() { Username = "Martin Vanquish" },
                new User { Username = "David Vanquish" },
                new User { Username = "Mama Brown" },
            };
            IList<User> CreatedUsers = await _userDataService.CreateUsersAsync(NewUsers);

            Assert.DoesNotContain(CreatedUsers, c => c.UserId == 0);
        }

        [Fact]
        public async Task UserDataServiceTests_CereateUsersWithIdToSeededDatabase_ReturnsNULL()
        {
            List<User> NewUsers = new()
            {
                new User() { UserId = 1, Username = "Martin Vanquish" },
                new User { UserId = 2, Username = "David Vanquish" },
                new User { UserId = 3, Username = "Mama Brown" },
            };
            IList<User> CreatedUsers = await _userDataService.CreateUsersAsync(NewUsers);
            Assert.True(CreatedUsers == null);
        }

        [Fact]
        public async Task UserDataServiceTests_CereateUsersNull_ReturnsNULL()
        {
           
            IList<User> CreatedUsers = await _userDataService.CreateUsersAsync(null);
            Assert.True(CreatedUsers == null);
        }
    }
}
