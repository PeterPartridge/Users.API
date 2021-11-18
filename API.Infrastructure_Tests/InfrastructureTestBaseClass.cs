using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Users.Infrastructure;
using Users.Infrastructure.DataService;

namespace API.Infrastructure_Tests
{
    public abstract class InfrastructureTestBaseClass
    {
        public ILogger<UserDataContext> _DataServiceLogger;
        public UserDataService _userDataService;
        public ServiceProvider _serviceProvider;

        public InfrastructureTestBaseClass()
        {
            _serviceProvider = new ServiceCollection().AddDbContext<UserDataContext>(options => options.UseInMemoryDatabase("User"),
                                                                                       ServiceLifetime.Scoped).
                                                                                       AddLogging()
                                                                                       .BuildServiceProvider();
            var factory = _serviceProvider.GetService<ILoggerFactory>();
            _DataServiceLogger = factory.CreateLogger<UserDataContext>();
            _userDataService = new UserDataService(_serviceProvider.GetService<UserDataContext>(), _DataServiceLogger);
            SeedData.SeedUsers(_serviceProvider.GetService<UserDataContext>());
        }
        
    }
}
