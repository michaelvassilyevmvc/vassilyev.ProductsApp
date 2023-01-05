using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace ProductsApp;

public class CsvOutputFormatter : TextOutputFormatter
{
	public CsvOutputFormatter()
	{
		SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
		SupportedEncodings.Add(Encoding.UTF8);
		SupportedEncodings.Add(Encoding.Unicode);
	}

	protected override bool CanWriteType(Type? type)
	{
		if (typeof(ProductDto).IsAssignableFrom(type)
			|| typeof(IEnumerable<ProductDto>).IsAssignableFrom(type))
		{
			return base.CanWriteType(type);
		}

		return false;
	}

	public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
		Encoding selectedEncoding)
	{
		var response = context.HttpContext.Response;
		var buffer = new StringBuilder();

		if (context.Object is IEnumerable<ProductDto>)
		{
			foreach (var company in (IEnumerable<ProductDto>)context.Object)
			{
				FormatCsv(buffer, company);
			}
		}
		else
		{
			FormatCsv(buffer, (ProductDto)context.Object);
		}

		await response.WriteAsync(buffer.ToString());
	}

	private static void FormatCsv(StringBuilder buffer, ProductDto product)
	{
		buffer.AppendLine($"{product.Id},\"{product.Name},\"{product.ProductionDate.ToString("d")}\",\"{product.ProductCompanyName}\",\"{product.ExpireDayCount}\",");
	}

}
