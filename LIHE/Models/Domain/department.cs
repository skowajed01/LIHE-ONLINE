using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LIHE.Models.Domain;

namespace LIHE.Models.Domain
{
    [Table("tbldeptmast", Schema = "academic")]
    public class department
    {
        [Key]
        public Guid transid { get; set; }
        public string deptname { get; set; }
        public string deptsname { get; set; }
        public string? status { get; set; }
        public string jobtype { get; set; }
        public string e_mail { get; set; }
        public string dept_cname { get; set; }
        public string orign_id { get; set; }
        public string ImageLocation { get; set; }
        public string webdeptname { get; set; }
        public string visblsts { get; set; }
        public string? department_email { get; set; }
        public string? rco { get; set; }
        public DateTime? rcm { get; set; }
        public string? luo { get; set; }
        public DateTime? lum { get; set; }
        public int slno { get; set; }
        public int delstatus { get; set; }
        public int serial_no { get; set; }
    }
}
