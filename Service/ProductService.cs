using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.ComponentModel.Design;
using System.Dynamic;

namespace Service;

internal sealed class ProductService : IProductService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;
    private readonly IProductLinks _productLinks;

    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IProductLinks productLinks)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
        _productLinks = productLinks;
    }

	public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllProductsAsync(LinkParameters linkParameters
		, bool trackChanges)
	{
		if (!linkParameters.ProductParameters.ValidPriceRange)
		{
			throw new MaxPriceRangeBadRequestException();
		}

		if (!linkParameters.ProductParameters.ValidPriceRange)
		{
			throw new MaxPriceRangeBadRequestException();
		}

		var productsWithMetaData = await _repository.Product.GetAllProductsAsync(linkParameters.ProductParameters,  trackChanges);

		var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

        var links = _productLinks.TryGenerateLinks(productsDto, linkParameters.ProductParameters.Fields, linkParameters.Context);

        return (LinkResponse: links, metaData: productsWithMetaData.MetaData);
	}

	public async Task<ProductDto> GetProductAsync(Guid id, bool trackChanges)
	{
		var product = await GetProductAndCheckIfItExists(id, trackChanges);

		var productDto = _mapper.Map<ProductDto>(product);
		return productDto;
	}

	public async Task<ProductDto> CreateProductAsync(ProductForCreationDto product)
	{
		var productEntity = _mapper.Map<Product>(product);

		_repository.Product.CreateProduct(productEntity);
		await _repository.SaveAsync();

		var productToReturn = _mapper.Map<ProductDto>(productEntity);

		return productToReturn;
	}

	public async Task<IEnumerable<ProductDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
	{
		if (ids is null)
			throw new IdParametersBadRequestException();

		var productEntities = await _repository.Product.GetByIdsAsync(ids, trackChanges);
		if (ids.Count() != productEntities.Count())
			throw new CollectionByIdsBadRequestException();

		var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

		return productsToReturn;
	}

	public async Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollectionAsync
		(IEnumerable<ProductForCreationDto> productCollection)
	{
		if (productCollection is null)
			throw new ProductCollectionBadRequest();

		var productEntities = _mapper.Map<IEnumerable<Product>>(productCollection);
		foreach (var product in productEntities)
		{
			_repository.Product.CreateProduct(product);
		}

		await _repository.SaveAsync();

		var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
		var ids = string.Join(",", productCollectionToReturn.Select(c => c.Id));

		return (products: productCollectionToReturn, ids: ids);
	}

	public async Task DeleteProductAsync(Guid productId, bool trackChanges)
	{
		var product = await GetProductAndCheckIfItExists(productId, trackChanges);

		_repository.Product.DeleteProduct(product);
		await _repository.SaveAsync();
	}

	public async Task UpdateProductAsync(
			Guid productId,
			ProductForUpdateDto productForUpdate, bool trackChanges
		)
	{
		var company = await GetProductAndCheckIfItExists(productId, trackChanges);

		_mapper.Map(productForUpdate, company);
		await _repository.SaveAsync();
	}

	private async Task<Product> GetProductAndCheckIfItExists(Guid id, bool trackChanges)
	{
		var product = await _repository.Product.GetProductAsync(id, trackChanges);
		if (product is null)
			throw new ProductNotFoundException(id);

		return product;
	}

    private async Task CheckIfProductExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges);

        if (product is null)
            throw new ProductNotFoundException(productId);
    }

    public async Task SaveChangesForPatchAsync(
			ProductForUpdateDto productToPatch, 
			Product productEntity
		)
    {
        _mapper.Map(productToPatch, productEntity);
        await _repository.SaveAsync();
    }

    public async Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid productId, bool trackChanges)
    {
		await CheckIfProductExists(productId, trackChanges);
		var productDb = await GetProductAndCheckIfItExists(productId, trackChanges);
		var productToPatch = _mapper.Map<ProductForUpdateDto>(productDb);
		return (productToPatch: productToPatch, productEntity: productDb);
    }
}
