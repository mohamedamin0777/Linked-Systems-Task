using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services.ProductServices.Dto;

namespace Linked_Systems_Task.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IReadOnlyList<ProductResultDto>> GetAllProducts()
            => await _productService.GetAllProductsAsync();

        [HttpGet("GetById{id}")]
        public async Task<ProductResultDto> GetProductById(int? id)
            => await _productService.GetProductByIdAsync(id);

        [HttpPost("AddProduct")]
        public async Task<ProductResultDto> AddProduct(ProductResultDto dto)
            => await _productService.AddProduct(dto);

        [HttpPut("{id}")]
        public async Task<ProductResultDto> UpdateProduct(ProductResultDto dto)
            => await _productService.UpdateProduct(dto);

        //{
        //    if (id is null)
        //        return BadRequest("Id is requiered!");

        //    var product = _unitOfWork.Products.GetByIdAsync(id);
        //    if (product is null)
        //        return BadRequest("the Id you entered doesn't exist");

        //    var mappedProduct = _mapper.Map<Product>(dto);
        //    _unitOfWork.Products.Update(mappedProduct);
        //    _unitOfWork.Complete();

        //    return Ok(mappedProduct);
        //}

        [HttpDelete("{id}")]
        public async Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id)
            => await _productService.DeleteProduct(id);
        //{
        //    //if (id is null)
        //    //    return BadRequest("Id is requiered!");

        //    var product = _unitOfWork.Products.GetByIdAsync(id);
        //    //if (product is null)
        //    //    return BadRequest("the Id you entered doesn't exist");

        //    //var mappedProduct = _mapper.Map<Product>(product);
        //    _unitOfWork.Products.Delete(product);
        //    _unitOfWork.Complete();

        //    return Ok(_unitOfWork.Products.GetAllAsync());
        //}
    }
}
