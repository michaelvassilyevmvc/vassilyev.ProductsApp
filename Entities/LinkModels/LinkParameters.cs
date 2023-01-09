using Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.LinkModels
{
    public record LinkParameters(ProductParameters ProductParameters, HttpContext Context);
}
