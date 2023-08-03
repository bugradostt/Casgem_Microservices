using CasgemMicroservices.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CasgemMicroservices.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
   
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}
