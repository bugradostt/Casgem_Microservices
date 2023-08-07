
using CasgemMicroservices.Catalog.Dtos.ProductDtos;
using CasgemMicroservices.Shared.Dtos;

namespace CasgemMicroservices.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetProductListAsync();
        Task<Response<List<ResultProductDto>>> GetProductListWithCategoryAsync();
        Task<Response<ResultProductDto>> GetProductByIdAsync(string id);
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteProductAsync(string id);
    }
}
