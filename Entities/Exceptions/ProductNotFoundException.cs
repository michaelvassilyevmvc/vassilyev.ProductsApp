namespace Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
	public ProductNotFoundException(Guid companyId)
		: base($"Продукт с id: {companyId} не существует в базе данных.")
	{
	}
}
