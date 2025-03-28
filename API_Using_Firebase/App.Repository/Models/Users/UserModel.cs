using Google.Cloud.Firestore;
using System;

namespace App.Repository.Models.Users
{
    [FirestoreData]
    public class UserModel 
    {
        [FirestoreProperty]
        public string Id { get; set; } = default!;

        [FirestoreProperty]
        public string FullName { get; set; } = default!;

        [FirestoreProperty]
        public string Email { get; set; } = default!;

        [FirestoreProperty]
        public string Password{ get; set; } = default!;


        [FirestoreProperty]
        public Timestamp BirtDay { get; set; }

        [FirestoreProperty]
        public Timestamp CreatedAt { get; set; }
    }
}
