using App.Repository.SupportInterface;

namespace App.Repository.Models.Products
{
    public interface IProductRepository : IGenericRepository<ProductModel>  
    {
        Task<(List<ProductModel>, int)> GetProductsByPageAsync(int pageNumber, int pageSize);
        Task<ProductModel?> GetProductByName(string name);
    }
}
