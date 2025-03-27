namespace App.Services.Services.UserServices.Create;
public record CreateUserRequest
    (
    string FullName,
    string Email,
    string Password
    );
