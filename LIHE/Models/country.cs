using System.ComponentModel.DataAnnotations;

namespace LIHE.Models
{
    public class country
    {
        [Key]
        public Guid transid { get; set; }
        public string countryname { get; set; }
        public string currency { get; set; }
        public string nationalityname { get; set; }
        public string callingcode { get; set; }
        public string rco { get; set; }
        public DateTime rcm { get; set; }
        public string luo { get; set; }
        public DateTime? lum { get; set; }
        public int sts { get; set; }
        public int delstatus { get; set; }
    }
}
