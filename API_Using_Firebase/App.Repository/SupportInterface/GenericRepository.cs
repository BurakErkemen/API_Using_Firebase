
using Google.Cloud.Firestore;

namespace App.Repository.SupportInterface
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FirestoreDb _firestoreDb;
        protected readonly CollectionReference _collectionName;

        public GenericRepository(FirebaseDbContext context, string collectionName)
        {
            _firestoreDb = context.GetFirestoreDb();
            _collectionName = _firestoreDb.Collection(collectionName);
        }

        // Create
        public Task AddAsync(T entity)
        {
            var document = _collectionName.Document();
            return document.SetAsync(entity);
        }

        // Update
        public async Task UpdateAsync(string id, T entity)
        {
            DocumentReference documentReference = _collectionName.Document(id);
            await documentReference.SetAsync(entity, SetOptions.MergeAll);
        }

        // Delete
        public async Task DeleteAsync(string id)
        {
            await _collectionName.Document(id).DeleteAsync();
        }

        // Tüm Verileri Getir
        public async Task<List<T>> GetAllAsync()
        {
            QuerySnapshot snapshots =await _collectionName.GetSnapshotAsync();
            return snapshots.Select(snapshot => snapshot.ConvertTo<T>()).ToList();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            DocumentSnapshot documentSnapshot =await _collectionName.Document(id).GetSnapshotAsync();
            return documentSnapshot.Exists ? documentSnapshot.ConvertTo<T>() : null;
        }

    }
}
