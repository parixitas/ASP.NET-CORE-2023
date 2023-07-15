using ASP_NET_CORE_API.Interfaces;
using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using ASP_NET_CORE_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { 
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(typeof(UserDetailResponse), 200)]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsers().ConfigureAwait(false);
            return Ok(new
            {
                Data = response
            });
        }


        [HttpGet("GetUserById")]
        [ProducesResponseType(typeof(SingleUserResponse), 200)]
        public async Task<IActionResult> GetUser(int UserId)
        {
            var response = await _userService.GetUser(UserId).ConfigureAwait(false);
            return Ok(new
            {
                Data = response
            });
        }

        [HttpPost("AddUserDetails")]
        [ProducesResponseType(typeof(SingleUserResponse), 200)]
        public async Task<IActionResult> AddUser(UserDetailRequest model)
        {
            var response = await _userService.AddUser(model).ConfigureAwait(false);
            return Ok(new
            {
                Data = response
            });
        }

    }
}
