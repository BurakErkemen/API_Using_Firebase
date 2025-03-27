using App.Repository.SupportInterface;

namespace App.Repository.Models.Users
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        //Task AddUserAsync(UserModel user);
        //Task<List<UserModel>> GetAllUsersAsync();
        //Task<UserModel?> GetUserByIdAsync(string userId);
        //Task UpdateUserAsync(string userId, string newName, string newEmail);
        //Task DeleteUserAsync(string userId);

        Task<UserModel?> GetUserByName(string name);
        Task<UserModel?> GetUserByEmail(string email);
    }
}
