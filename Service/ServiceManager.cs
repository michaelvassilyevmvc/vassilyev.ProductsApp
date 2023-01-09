using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IProductService> _companyService;

	public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IDataShaper<ProductDto> dataShaper)
	{
		_companyService = new Lazy<IProductService>(() =>
			new ProductService(repositoryManager, logger, mapper, dataShaper));
	}

	public IProductService ProductService => _companyService.Value;
}
