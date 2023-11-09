using System.ComponentModel.DataAnnotations;

namespace LIHE.Models
{
    public class Registration
    {
        [Required]
       // [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
