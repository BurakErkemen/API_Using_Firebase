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

        public Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResult> DeleteAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<UserResponse>>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<UserResponse>> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

    }
}
