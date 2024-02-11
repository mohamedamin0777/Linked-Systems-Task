using Services.Services.ProductServices.Dto;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductResultDto>> GetAllProductsAsync();
        Task<ProductResultDto> GetProductByIdAsync(int? id);
        Task<ProductResultDto> AddProduct(ProductResultDto product);
        Task<ProductResultDto>UpdateProduct(ProductResultDto product);
        Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id);
    }
}
