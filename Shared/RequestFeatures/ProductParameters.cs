namespace Shared.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "name";
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = (decimal)int.MaxValue;

        public bool ValidPriceRange => MaxPrice > MinPrice;

        public string SearchTerm { get; set; } = String.Empty;

    }
}
