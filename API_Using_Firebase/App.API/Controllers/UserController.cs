using App.Services.Services.UserServices;
using App.Services.Services.UserServices.Create;
using App.Services.Services.UserServices.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : CustomBaseController
    {

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await userService.GetAllUsersAsync();
            return CreateActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var result = await userService.GetUserByIdAsync(Id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            var result = await userService.CreateUserAsync(request);
            return CreateActionResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var result = await userService.UpdateUserAsync(request);
            return CreateActionResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string Id)
        {
            var result = await userService.DeleteAsync(Id);
            return CreateActionResult(result);
        }

    }
}
