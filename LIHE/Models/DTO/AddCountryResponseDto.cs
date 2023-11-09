using System.ComponentModel.DataAnnotations;

namespace LIHE.Models.DTO
{
	public class AddCountryResponseDto
	{

		public Guid transid { get; set; }
		public string countryname { get; set; }
		public string currency { get; set; }
		public string nationalityname { get; set; }
		public string callingcode { get; set; }
	}
}
