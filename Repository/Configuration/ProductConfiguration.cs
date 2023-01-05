using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasData
		(
			new Product
			{
				Id = new Guid("A2B62EC8-00FF-437B-B6EF-39B68CFB2ED3"),
				Name = "FLASH energy",
				CompanyName = "Балтика",
				ProductionDate = DateTime.UtcNow,
				ExpiresDate = DateTime.UtcNow.AddDays(3)
			},
			new Product
			{
				Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gorilla Energy",
                CompanyName = "Gorrila",
                ProductionDate = DateTime.UtcNow.AddDays(-13),
                ExpiresDate = DateTime.UtcNow.AddDays(10)
            },
			new Product
			{
				Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Monster",
                CompanyName = "Red Bull",
                ProductionDate = DateTime.UtcNow.AddDays(10),
                ExpiresDate = null,
            }
		);
	}
}
