using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.UserBook;

namespace ReadingClubSPI_.Net.Controllers
{
    /// <summary>
    /// Controller for managing user registration and login.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user information to register.</param>
        /// <returns>The registered user.</returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(AuthorizedUserBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RegistrationUserBook user)
        {
            var registeredUser = _userService.Register(user);
            return Ok(registeredUser);
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="user">The user login information.</param>
        /// <returns>The logged-in user.</returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(AuthorizedUserBook), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginUserBook user)
        {
            var registeredUser = _userService.Login(user);
            return Ok(registeredUser);
        }
    }
}