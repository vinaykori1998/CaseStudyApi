using System.ComponentModel.DataAnnotations;

namespace CaseStudyApi.Models
{
    public class Seller
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string SName { get; set; }
        [Required]
        public string SAddress { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^[1-9][0-9]{9}")]
        public string PhNo { get; set; }
    }
}
