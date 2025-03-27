using App.Services.Services.UserServices.Create;
using App.Services.Services.UserServices.Update;

namespace App.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request);
        Task<ServiceResult> DeleteAsync(string userId);
        Task<ServiceResult<UserResponse>> GetUserByIdAsync(string userId);
        Task<ServiceResult<List<UserResponse>>> GetAllUsersAsync();
    }
}
