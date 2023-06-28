using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProduct();
        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel  model);
        Task<ProductModel> UpdateProduct(ProductModel model);
        Task <bool> DeleteProduct(long id);
    }
}
