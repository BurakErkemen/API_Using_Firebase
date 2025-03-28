using App.Repository.SupportInterface;

namespace App.Repository.Models.Products
{
    public class ProductRepository(FirebaseDbContext context) : GenericRepository<ProductModel>(context, "Products"), IProductRepository
    {
        public async Task<ProductModel?> GetProductByName(string name)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("Name", name)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<ProductModel>())
                .FirstOrDefault();
        }

        public async Task<(List<ProductModel>, int)> GetProductsByPageAsync(int pageNumber, int pageSize)
        {
            var query =  _collectionName
                .Offset((pageNumber - 1) * pageSize)
                .Limit(pageSize);

            var querySnapshot = await query.GetSnapshotAsync();

            var products = querySnapshot.Documents
                .Select(doc => doc.ConvertTo<ProductModel>())
                .ToList();

            var totalCount = await _collectionName.GetSnapshotAsync();

            return (products, totalCount.Documents.Count);

        }


    }
}
