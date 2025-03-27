
using App.Repository.SupportInterface;
using Google.Api;

namespace App.Repository.Models.Users
{
    public class UserRepository(FirebaseDbContext context) : GenericRepository<UserModel>(context, "Users"), IUserRepository
    {
        public async Task<UserModel?> GetUserByEmail(string email)
        {
            var querySnapshot = await _collectionName
     .WhereEqualTo("Email", email)  // "Email" alanı ile sorgulama yapıyoruz
     .GetSnapshotAsync();

            // Eğer bir kullanıcı varsa, döndür
            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<UserModel>())
                .FirstOrDefault();  // İlk bulunan kullanıcıyı döndür


        }

        public async Task<UserModel?> GetUserByName(string name)
        {
            var querySnapshot = await _collectionName
               .WhereEqualTo("Name", name)  // "Name" alanı ile sorgulama yapıyoruz
               .GetSnapshotAsync();

            // Eğer bir kullanıcı varsa, döndür
            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<UserModel>())
                .FirstOrDefault();  // İlk bulunan kullanıcıyı döndür
        }
    }
}
