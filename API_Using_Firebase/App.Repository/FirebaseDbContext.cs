using Google.Cloud.Firestore;

namespace App.Repository
{
    public class FirebaseDbContext
    {
        private readonly FirestoreDb _firestoreDb;

        // Constructor that accepts the firebase credential path
        public FirebaseDbContext(string firebaseCredentialPath)
        {
            string firebaseCredentialPat1h = "D:\\Github\\API_Using_Firebase\\API_Using_Firebase\\App.Repository\\firebase_credentials.json";

            // Set the Google application credentials using the provided path
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", firebaseCredentialPat1h);

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