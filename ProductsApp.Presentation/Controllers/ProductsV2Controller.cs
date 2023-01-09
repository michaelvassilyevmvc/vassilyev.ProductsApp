using Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.RequestFeatures;

namespace ProductsApp.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repo;

        public ProductsV2Controller(IRepositoryManager repo) => _repo = repo;

        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var products = await _repo.Product.GetAllProductsAsync(productParameters, false);
            var productsV2 = products.Select(x => $"{x.Name} V2");

            return Ok(productsV2);
        }
    }
}
