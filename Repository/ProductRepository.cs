using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
	public ProductRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters,bool trackChanges)
	{
        var products =
			await FindAll(trackChanges)
		.FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
		.Search(productParameters.SearchTerm)
		.Sort(productParameters.OrderBy)
        .ToListAsync();

		return PagedList<Product>
			.ToPagedList(source: products, pageNumber: productParameters.PageNumber, pageSize: productParameters.PageSize);
    }
		

	public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(productId), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateProduct(Product product) => Create(product);

	public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
		await FindByCondition(x => ids.Contains(x.Id), trackChanges)
		.ToListAsync();

	public void DeleteProduct(Product product) => Delete(product);
}
