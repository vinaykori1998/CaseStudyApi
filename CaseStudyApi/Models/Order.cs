using System.ComponentModel.DataAnnotations;

namespace CaseStudyApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PId { get; set; }
        [Required]
        public int CId { get; set; }
    }
}
