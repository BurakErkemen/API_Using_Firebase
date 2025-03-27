using Google.Cloud.Firestore;

namespace App.Repository.Models.Products
{
    [FirestoreData]
    public class ProductModel
    {
        [FirestoreProperty]
        public string ProductId { get; set; } = default!;

        [FirestoreProperty]
        public string Name { get; set; } = default!;

        [FirestoreProperty]
        public decimal Price { get; set; }

        [FirestoreProperty]
        public int Stock{ get; set; }
    }
}