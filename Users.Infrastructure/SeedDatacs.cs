using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Model;

namespace Users.Infrastructure
{
    public static class SeedData
    {
        public static void SeedUsers(UserDataContext userDataContext)
        {
            List<User> users = new();
            users.Add(new User { Username = "Billy Bob" });
            users.Add(new User { Username = "Shelly Bob" });
            users.Add(new User { Username = "Kelly Bob" });
            userDataContext.User.AddRange(users);
            userDataContext.SaveChanges();
        }

    }
}
