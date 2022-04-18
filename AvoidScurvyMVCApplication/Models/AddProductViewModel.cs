using System.ComponentModel.DataAnnotations;

namespace AvoidScurvyMVCApplication.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        [Display(Name = "Daily amount of Vitamin C (%)")]
        [Range(0, 50000)]
        public int VitCDailyAmount { get; set; }
        [Required]
        public string UPC { get; set; }
        [Required]
        public decimal StarRating { get; set; }
    }
}
