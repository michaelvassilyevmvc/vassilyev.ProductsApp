namespace Entities.Exceptions;

public sealed class ProductCollectionBadRequest : BadRequestException
{
	public ProductCollectionBadRequest()
		: base("Коллекция продуктов равна null.")
	{
	}
}
