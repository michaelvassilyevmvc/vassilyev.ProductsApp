using Entities.Models;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;

namespace Contracts
{
    public interface IProductLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<ProductDto> productsDto,
            string fields, HttpContext httpContext);
    }
}
