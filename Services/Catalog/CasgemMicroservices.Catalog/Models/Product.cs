using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CasgemMicroservices.Catalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

    }
}
