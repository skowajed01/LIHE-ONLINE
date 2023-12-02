using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIHE.Models.Domain
{
    [Table("tbljobtype", Schema = "academic")]
    public class jobtypemast
    {
        [Key]
        public Guid transid { get; set; }
        public string jobtype { get; set; }
        public string jobsname { get; set; }
        public string? status { get; set; }
    }
}
