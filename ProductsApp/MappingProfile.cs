using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace ProductsApp;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Product, ProductDto>()
			.ForMember(c => c.ExpireDayCount,
				opt => opt.MapFrom(x => x.ExpiresDate.HasValue ? (x.ExpiresDate.Value - x.ProductionDate).TotalDays : 0));

		CreateMap<ProductForCreationDto, Product>();
		CreateMap<ProductForUpdateDto, Product>().ReverseMap();
	}
}
