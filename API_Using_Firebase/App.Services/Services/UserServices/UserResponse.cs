using Google.Cloud.Firestore;

namespace App.Services.Services.UserServices;
public record UserResponse
(
    string UserId,
    string FullName,
    string Email,
    Timestamp BirtDay
    );