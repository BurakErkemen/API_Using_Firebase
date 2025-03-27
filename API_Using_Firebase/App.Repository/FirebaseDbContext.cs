using Google.Cloud.Firestore;

namespace App.Repository
{
    public class FirebaseDbContext
    {
        private readonly FirestoreDb _firestoreDb;

        // Constructor that accepts the firebase credential path
        public FirebaseDbContext(string firebaseCredentialPath)
        {
            // Set the Google application credentials using the provided path
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", firebaseCredentialPath);

            // Connect to Firestore using the project ID
            _firestoreDb = FirestoreDb.Create("apiusingfirebase-5611a"); // Replace with your actual Firebase project ID
            Console.WriteLine($"Firestore bağlandı: {_firestoreDb.ProjectId}");
        }

        // Method to get the FirestoreDb instance
        public FirestoreDb GetFirestoreDb()
        {
            return _firestoreDb;
        }
    }
}