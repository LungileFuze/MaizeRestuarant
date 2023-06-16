using System.ComponentModel.DataAnnotations;

namespace MaizeRestuarantWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be in a range of 1-100")]
        public int DisplayOrder { get; set; }
    }
}
