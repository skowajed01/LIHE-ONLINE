using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIHE.Models.Domain
{
	[Table("tbl_countrymast", Schema = "academic")]
	public class Country
	{
		[Key]
		public Guid transid { get; set; }
		public string countryname { get; set; }
		public string currency { get; set; }
		public string nationalityname { get; set; }
		public string callingcode { get; set; }
		public string? rco { get; set; }
		public DateTime? rcm { get; set; }
		public string? luo { get; set; }
		public DateTime? lum { get; set; }
		public int sts { get; set; }
		public int delstatus { get; set; }
	}
}
