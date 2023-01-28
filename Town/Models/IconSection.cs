using System.ComponentModel.DataAnnotations;

namespace Town.Models
{
    public class IconSection
    {
        public int Id { get; set; }
        [StringLength(maximumLength:25)]
        public string Title { get; set; }
        [StringLength(maximumLength:150)]
        public string Desc { get; set; }
        [StringLength(maximumLength:100)]
        public string Icon { get; set; }
    }
}
