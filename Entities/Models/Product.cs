using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Product
{
	[Column("ProductId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Наименование продукта обязательное поле.")]
	[MaxLength(60, ErrorMessage = "Максимальная длина наименования 60 символов.")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "Дата производства обязательное поле.")]
	public DateTime ProductionDate { get; set; }
	public DateTime? ExpiresDate { get; set; }

	public string? CompanyName { get; set; }

	
}
