using Microsoft.AspNetCore.Mvc;
using Users.Domain.Interfaces;
using Users.Domain.Model;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserDataService _userDataService;

        public UsersController(ILogger<UsersController> logger, IUserDataService userDataService)
        {
            _logger = logger;
            _userDataService = userDataService;
        }

        [HttpPost(Name = "Post")]
        public async Task<IActionResult> Post(IList<string> usernames)
        {
            if (usernames == null)
            {
                return BadRequest($"List of Names is required");
            }
            IList<User> existingUsers = await _userDataService.GetUsersAsync();
            List<User> users = new List<User>();
            foreach (var username in usernames)
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return BadRequest($"null or empty names are not allowed.");
                }
                else if (existingUsers.Any(e => e.Username.Contains(username)))
                {
                    return BadRequest($"User name already exists {username}");
                }
                else if (usernames.Where(userName => userName == username).Count() > 1)
                {
                    return BadRequest($"duplicate User name {username} please remove");
                }

                else
                {
                    users.Add(new User() { Username = username });
                }
            }

            IList<User> CreatedUsers = await _userDataService.CreateUsersAsync(users);

            if (CreatedUsers == null)
            {
                return StatusCode(500, "Unable to create users.");
            }
            return Ok(CreatedUsers);
        }
        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            IList<User> users = await _userDataService.GetUsersAsync();
            if (users == null)
            {
                return StatusCode(500, "Unable to find user data.");
            }
            return Ok(users.OrderBy(u => u.UserId));
        }
        [HttpPut(Name = "Put/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username cannot be null or empty");
            }
            User user = await _userDataService.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest("Unable to find user");
            }

            IList<User> existingUsers = await _userDataService.GetUsersAsync();
            if (existingUsers.Any(e => e.Username.Contains(username)))
            {
                return BadRequest($"User name already exists {username}");
            }
            user.Username = username;
            User UpdatedUser = await _userDataService.UpdateUserAsync(user);

            if (UpdatedUser == null)
            {
                return StatusCode(500, "Unable to update user data.");
            }

            return Ok(UpdatedUser);
        }
        [HttpDelete(Name = "Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id passed.");
            }
            User user = await _userDataService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User deos not exist.");
            }
            bool removeuser = await _userDataService.DeleteUserAsync(user);
            if (!removeuser)
            {
                return StatusCode(500, "Unable to remove user data.");
            }
            return Ok();
        }
    }
}