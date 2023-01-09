using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IProductService
{
	Task<(IEnumerable<Entity> products,MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
	Task<ProductDto> GetProductAsync(Guid companyId, bool trackChanges);
	Task<ProductDto> CreateProductAsync(ProductForCreationDto company);
	Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
	Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollectionAsync
		(IEnumerable<ProductForCreationDto> productCollection);
	Task DeleteProductAsync(Guid productId, bool trackChanges);
	Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges);

	Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(
		Guid productId, bool trackChanges);
    Task SaveChangesForPatchAsync(ProductForUpdateDto employeeToPatch, Product employeeEntity);
}
