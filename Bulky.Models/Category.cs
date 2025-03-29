using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="Category Name")]
        public string Name { get; set; }
        [Display(Name= "Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be between 1 and 100.")]
        public int DisplayOrder { get; set; }
    }
}
