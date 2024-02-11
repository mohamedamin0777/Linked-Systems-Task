using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Services.Interfaces;
using Services.Services.ProductServices.Dto;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductResultDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductResultDto>>(products);

            return mappedProducts;
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int? id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductResultDto>(product);

            return mappedProduct;
        }

        public async Task<ProductResultDto> AddProduct(ProductResultDto product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            await _unitOfWork.Products.AddAsync(mappedProduct);
            _unitOfWork.Complete();

            return product;
        }

        public async Task<ProductResultDto> UpdateProduct(ProductResultDto dto)
        {
            var mappedProduct = _mapper.Map<Product>(dto);
            _unitOfWork.Products.Update(mappedProduct);
            _unitOfWork.Complete();

            return dto;
        }

        public async Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();

            var products = await _unitOfWork.Products.GetAllAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductResultDto>>(products);

            return mappedProducts;
        }
    }
}
