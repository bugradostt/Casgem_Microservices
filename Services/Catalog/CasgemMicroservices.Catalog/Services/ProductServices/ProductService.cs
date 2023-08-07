using AutoMapper;
using CasgemMicroservices.Catalog.Dtos.CategoryDtos;
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

        public async Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
            return Response<CreateProductDto>.Success(_mapper.Map<CreateProductDto>(value), 200);

        }

        public async Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            var value = await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
            if (value.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Silinecek ürün bulunamadı", 404);
            }
        }
       
        public async Task<Response<ResultProductDto>> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultProductDto>.Fail("Böyle bir id bulunamadı", 404);

            }
            else
            {
                return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(value), 200);
            }
        }

        public async Task<Response<List<ResultProductDto>>> GetProductListAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);

        }

        public async Task<Response<List<ResultProductDto>>> GetProductListWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            if (values.Any())
            {
                foreach (var i in values)
                {
                    i.Category = await _categoryCollection.Find(x => x.CategoryId == i.CategoryId).FirstOrDefaultAsync();
                }

            }
            else
            {
                values = new List<Product>();
            }
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);

        }

        public async  Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
            if (result == null)
            {
                return Response<UpdateProductDto>.Fail("Güncellenecek veri bulunamadı", 404);
            }
            else
            {
                return Response<UpdateProductDto>.Success(204);
            }
        }
    }
}
