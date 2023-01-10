using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(
        IRepositoryManager repositoryManager, 
        ILoggerManager logger, 
        IMapper mapper, 
        IProductLinks productLinks,
        UserManager<User> userManager,
        IConfiguration configuration)
    {
        _productService = new Lazy<IProductService>(() =>
            new ProductService(repositoryManager, logger, mapper, productLinks));

        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager, configuration));
    }

    public IProductService ProductService => _productService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
