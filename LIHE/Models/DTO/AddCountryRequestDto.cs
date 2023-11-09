using System.ComponentModel.DataAnnotations;

namespace LIHE.Models.DTO
{
	public class AddCountryRequestDto
	{

		[Required(ErrorMessage = "country name is required")]

		public string countryname { get; set; }
		[Required(ErrorMessage = "currency  is required")]
		public string currency { get; set; }
		[Required(ErrorMessage = "nationalitynameis required")]
		public string nationalityname { get; set; }
		[Required(ErrorMessage = "callingcode required")]
		public string callingcode { get; set; }


	}
}
