using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Users.API.Controllers;
using Users.Infrastructure;
using Users.Infrastructure.DataService;

namespace API.EndPoint_Tests
{
    public abstract class APITestBaseClass
    {
        private ILogger<UserDataContext> _DataServiceLogger;
        private UserDataService _userDataService;
        private ServiceProvider _serviceProvider;

        public UsersController _userController;
        private UserDataContext? _UserDbContext;

        public APITestBaseClass()
        {
            var serviceProvider = new ServiceCollection().AddDbContext<UserDataContext>(options => options.UseInMemoryDatabase("User"),
                                                                                       ServiceLifetime.Scoped).
                                                                                       AddLogging()
                                                                                       .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            _DataServiceLogger = factory.CreateLogger<UserDataContext>();
            _UserDbContext = serviceProvider.GetService<UserDataContext>();
            _userDataService = new UserDataService(_UserDbContext, _DataServiceLogger);
            var controllerLogger = factory.CreateLogger<UsersController>();
            _userController = new(controllerLogger, _userDataService);
            SeedData.SeedUsers(_UserDbContext);


        }

    }
}
