using Microsoft.AspNetCore.Http;

namespace Services.Services.ProductServices.Dto
{
    public class ProductResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
