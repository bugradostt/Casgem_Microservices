using AutoMapper;
using CasgemMicroservices.Catalog.Dtos.ProductDtos;
using CasgemMicroservices.Catalog.Models;
using CasgemMicroservices.Catalog.Settings.Abstract;
using CasgemMicroservices.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservices.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {

            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }

        public Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultProductDto>> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultProductDto>>> GetProductListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
