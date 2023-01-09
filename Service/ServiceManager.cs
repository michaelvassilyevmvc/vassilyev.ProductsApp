using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IProductLinks productLinks)
    {
        _productService = new Lazy<IProductService>(() =>
            new ProductService(repositoryManager, logger, mapper, productLinks));
    }

    public IProductService ProductService => _productService.Value;
}
