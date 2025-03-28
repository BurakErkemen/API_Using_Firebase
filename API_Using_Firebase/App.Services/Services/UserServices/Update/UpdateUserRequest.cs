﻿using Google.Cloud.Firestore;

namespace App.Services.Services.UserServices.Update;

public record UpdateUserRequest
    (string UserId,
    string FullName,
    string Email,
    Timestamp BirtDay
    );