namespace Shared.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = (decimal)int.MaxValue;

        public bool ValidPriceRange => MaxPrice > MinPrice;
    }
}
