using App.Services.Services.UserServices;
using App.Services.Services.UserServices.Create;
using App.Services.Services.UserServices.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        // Constructor, IUserService'nin bağımlılığını alır
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllUsersAsync();
            return CreateActionResult(result);
        }

        [HttpGet("getbyId/{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var result = await _userService.GetUserByIdAsync(Id);
            return CreateActionResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            var result = await _userService.CreateUserAsync(request);
            return CreateActionResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var result = await _userService.UpdateUserAsync(request);
            return CreateActionResult(result);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteAsync(string Id)
        {
            var result = await _userService.DeleteAsync(Id);
            return CreateActionResult(result);
        }
    }
}
