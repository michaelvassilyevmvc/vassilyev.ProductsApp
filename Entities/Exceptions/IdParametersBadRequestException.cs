namespace Entities.Exceptions;

public sealed class IdParametersBadRequestException : BadRequestException
{
	public IdParametersBadRequestException()
		: base("Идентификаторы равны null")
	{
	}
}
