using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record ProductForManipulationDto
{
	[Required(ErrorMessage = "Наименование продукта обязательное поле.")]
	[MaxLength(60, ErrorMessage = "Наименование должно содержать не более 60 символов.")]
	public string? Name { get; init; }

    [Required(ErrorMessage = "Дата производства обязательное поле.")]
    [DateLessThan("ExpiresDate", ErrorMessage = "Production Date must be less than Expires Date")]
    public DateTime ProductionDate { get; set; }
    public DateTime? ExpiresDate { get; set; }

    public string? CompanyName { get; set; }
    public decimal? Price { get; set; }
}
