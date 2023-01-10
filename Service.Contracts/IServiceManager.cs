namespace Service.Contracts;

public interface IServiceManager
{
	IProductService ProductService { get; }
    IAuthenticationService AuthenticationService { get; }
}
