using Users.Domain.Model;

namespace Users.Domain.Interfaces
{
    public interface IUserDataService
    {
        Task<IList<User>> GetUsersAsync();
        Task<IList<User>> CreateUsersAsync(IList<User> users);
        Task<bool> DeleteUserAsync(User UserToDelete);
        Task<User> GetUserByIdAsync(int UserId);
        Task<User> UpdateUserAsync(User user);
    }
}