using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
	public ProductRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
		await FindAll(trackChanges)
		.OrderBy(c => c.Name)
		.ToListAsync();

	public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(productId), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateProduct(Product product) => Create(product);

	public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
		await FindByCondition(x => ids.Contains(x.Id), trackChanges)
		.ToListAsync();

	public void DeleteProduct(Product product) => Delete(product);
}
