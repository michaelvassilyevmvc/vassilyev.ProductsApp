using Entities.LinkModels;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Presentation.ActionFilters;
using ProductsApp.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace ProductsApp.Presentation.Controllers;

[Route("api/products")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductsController(IServiceManager service) => _service = service;

    [HttpOptions]
    public IActionResult GetProductOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }

    [HttpGet(Name = "GetProducts")]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
    {

        var linkParams = new LinkParameters(productParameters, HttpContext);
        var result = await _service.ProductService.GetAllProductsAsync(linkParams, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    [HttpGet("{id:guid}", Name = "ProductById")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = true)]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _service.ProductService.GetProductAsync(id, trackChanges: false);
        return Ok(product);
    }

    [HttpGet("collection/({ids})", Name = "ProductCollection")]
    public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var products = await _service.ProductService.GetByIdsAsync(ids, false);

        return Ok(products);
    }

    [HttpPost(Name = "CreateProduct")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
    {
        var createdProduct = await _service.ProductService.CreateProductAsync(product);

        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateProductCollection
        ([FromBody] IEnumerable<ProductForCreationDto> productCollection)
    {
        var result = await _service.ProductService.CreateProductCollectionAsync(productCollection);

        return CreatedAtRoute("ProductCollection", new { result.ids }, result.products);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _service.ProductService.DeleteProductAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto product)
    {
        await _service.ProductService.UpdateProductAsync(id, product, true);

        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateForProduct(Guid id,
        [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
    {
        if (patchDoc is null) return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.ProductService.GetProductForPatchAsync(id, true);

        patchDoc.ApplyTo(result.productToPatch, ModelState);

        TryValidateModel(result.productToPatch);

        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

        await _service.ProductService.SaveChangesForPatchAsync(result.productToPatch, result.productEntity);

        return NoContent();
    }
}
