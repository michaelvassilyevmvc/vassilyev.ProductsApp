using Entities.Models;

namespace Repository.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, decimal minPrice, decimal maxPrice) =>
            products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return products;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
