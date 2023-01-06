namespace Entities.Exceptions
{
    public class MaxPriceRangeBadRequestException : BadRequestException
    {
        public MaxPriceRangeBadRequestException() : base("Максимальная цена не может быть ниже минимальной")
        {

        }
    }
}
