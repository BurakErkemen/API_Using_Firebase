namespace App.Services.Services.UserServices;
public record UserResponse
(
    string UserId,
    string FullName,
    string Email,
    DateTime BirtDay
    );