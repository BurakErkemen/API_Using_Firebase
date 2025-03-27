using App.Repository.Models.Users;
using App.Services.Services.UserServices.Create;
using App.Services.Services.UserServices.Update;
using System.Net;

namespace App.Services.Services.UserServices
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
           var anyUser = await userRepository.GetUserByEmail(request.Email);
            if (anyUser is not null)
                return ServiceResult<CreateUserResponse>.Fail("User's email already exists!", HttpStatusCode.BadRequest);
            

            var user = new UserModel
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password
            };

            await userRepository.AddAsync(user);

            return ServiceResult<CreateUserResponse>.Success(new CreateUserResponse(user.Id),
                HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var anyUser = await userRepository.GetByIdAsync(request.UserId);

            if (anyUser is null) return ServiceResult.Fail("User not found!", HttpStatusCode.NotFound);

            anyUser.FullName = request.FullName;
            anyUser.Email = request.Email;
            anyUser.BirtDay = request.BirtDay;

            await userRepository.UpdateAsync(anyUser.Id,anyUser);

            return ServiceResult.Success(HttpStatusCode.NoContent);

            throw new NotImplementedException();
        }
        public async Task<ServiceResult> DeleteAsync(string userId)
        {
            var anyUser = await userRepository.GetByIdAsync(userId);

            if (anyUser is null) return ServiceResult.Fail("User Not Found!", HttpStatusCode.NotFound);

            await userRepository.DeleteAsync(userId);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<UserResponse>>> GetAllUsersAsync()
        {
            var user = await userRepository.GetAllAsync();
            var userResponse = user.Select(x => new UserResponse(x.Id, x.FullName, x.Email, x.BirtDay)).ToList();

            return ServiceResult<List<UserResponse>>.Success(userResponse, HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<UserResponse>> GetUserByIdAsync(string userId)
        {
            var anyUser = await userRepository.GetByIdAsync(userId);

            if (anyUser is null) return ServiceResult<UserResponse>.Fail("User Not Found!", HttpStatusCode.NotFound);

            var userResponse = new UserResponse(anyUser.Id, anyUser.FullName, anyUser.Email, anyUser.BirtDay);

            return ServiceResult<UserResponse>.Success(userResponse, HttpStatusCode.NoContent);
        }

    }
}
