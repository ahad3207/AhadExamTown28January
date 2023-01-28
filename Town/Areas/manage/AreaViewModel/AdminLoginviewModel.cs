using System.ComponentModel.DataAnnotations;

namespace Town.Areas.manage.AreaViewModel
{
    public class AdminLoginviewModel
    {
        [Required]
        [StringLength(maximumLength:25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 25,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
