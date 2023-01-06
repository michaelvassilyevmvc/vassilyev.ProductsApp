namespace Shared.DataTransferObjects;

public record ProductDto
{
	public Guid Id { get; init; }
	public string? Name { get; init; }
	public string? ProductCompanyName { get; set; }
	public DateTime ProductionDate { get; set; }
	public int? ExpireDayCount { get; set; }
	public decimal? Price { get; set; }

}
