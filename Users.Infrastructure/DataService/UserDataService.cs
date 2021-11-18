using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Interfaces;
using Users.Domain.Model;

namespace Users.Infrastructure.DataService
{
    public class UserDataService : IUserDataService
    {
        private UserDataContext _userDataContext;
        private ILogger<UserDataContext> _logger;

        public UserDataService(UserDataContext userDataContext, ILogger<UserDataContext> logger)
        {
            _userDataContext = userDataContext;
            _logger = logger;
        }
        public async Task<IList<User>> GetUsersAsync()
        {
            try
            {
                return await _userDataContext.User.ToListAsync();
            }
            catch (Exception ex)
            {
                StringBuilder errorString = new StringBuilder();
                errorString.AppendLine($"GetUsers has failed");
                errorString.AppendLine($"Error message: {ex.Message}");
                errorString.AppendLine($"Stack trace: {ex.StackTrace}");
                _logger.LogError(errorString.ToString());
                return null;
            }
        }

        public async Task<User> GetUserByIdAsync(int UserId)
        {
            try
            {
                return await _userDataContext.User.FirstOrDefaultAsync(u => u.UserId == UserId);

            }
            catch (Exception ex)
            {
                StringBuilder errorString = new StringBuilder();
                errorString.AppendLine($"GetUsers has failed");
                errorString.AppendLine($"Error message: {ex.Message}");
                errorString.AppendLine($"Stack trace: {ex.StackTrace}");
                _logger.LogError(errorString.ToString());
                return null;
            }
        }

        public async Task<IList<User>> CreateUsersAsync(IList<User> users)
        {
            if(users == null)
            {
                _logger.LogError("null object passed to CreateUsersAsync function");
                return null;
            }
            try
            {
                await _userDataContext.User.AddRangeAsync(users);
                await _userDataContext.SaveChangesAsync();
                return users;
            }
            catch (Exception ex)
            {
                StringBuilder errorString = new StringBuilder();
                errorString.AppendLine($"CreateUsersAsync has failed");
                errorString.AppendLine($"Error message: {ex.Message}");
                errorString.AppendLine($"Stack trace: {ex.StackTrace}");
                _logger.LogError(errorString.ToString());
                return null;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                _logger.LogError("null object passed to UpdateUserAsync function");
                return null;
            }
            try
            {
                _userDataContext.User.Update(user);
                int removedUser = await _userDataContext.SaveChangesAsync();
                if (removedUser > 0)
                {
                    return user;
                }
                _logger.LogError("Changed has not been saved");
                return null;
            }
            catch (Exception ex)
            {
                StringBuilder errorString = new StringBuilder();
                errorString.AppendLine($"UpdateUsersAsync has failed");
                errorString.AppendLine($"Error message: {ex.Message}");
                errorString.AppendLine($"Stack trace: {ex.StackTrace}");
                _logger.LogError(errorString.ToString());
                return null;
            }
        }
        public async Task<bool> DeleteUserAsync(User UserToDelete)
        {
            if(UserToDelete == null)
            {
                _logger.LogError("null object passed to DeleteUserAsync function");
                return false;
            }
            try
            {
                _userDataContext.User.Remove(UserToDelete);
                int removedUser = await _userDataContext.SaveChangesAsync();
                if (removedUser > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                StringBuilder errorString = new StringBuilder();
                errorString.AppendLine($"DeleteUsersAsync has failed");
                errorString.AppendLine($"Error message: {ex.Message}");
                errorString.AppendLine($"Stack trace: {ex.StackTrace}");
                _logger.LogError(errorString.ToString());
                return false;
            }
        }

    }
}
