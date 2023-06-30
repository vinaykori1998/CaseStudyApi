using System.ComponentModel.DataAnnotations;

namespace CaseStudyApi.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string PName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int SId { get; set; }
        public List<String> CategoryList = new List<string> { "Beverages", "Dairy", "Snacks", "Frozen" };

    }
}
