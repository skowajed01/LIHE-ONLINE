using System.ComponentModel.DataAnnotations;

namespace LIHE.Models.DTO
{
    public class DepartmentRequestDto
    {
        [Required(ErrorMessage = "deptname name is required")]
        public string deptname { get; set; }
        [Required(ErrorMessage = "deptsname  is required")]
        public string deptsname { get; set; }
        [Required(ErrorMessage = "jobtype required")]
        public string jobtype { get; set; }
     
    }
}
