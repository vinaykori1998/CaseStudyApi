using System.ComponentModel.DataAnnotations;

namespace CaseStudyApi.Models
{
    public class Customer { 
    [Key]
    public int CId { get; set; }
    [Required]
    [StringLength(25)]
    public string Cname { get; set; }

    [Required]
    [StringLength(10)]
    [RegularExpression("^[1-9][0-9]{9}")]
    public string Phno { get; set; }

    [Required]
    public string CAddress { get; set; }
}
}
