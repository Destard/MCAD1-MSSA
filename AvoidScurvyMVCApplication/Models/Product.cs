using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AvoidScurvyMVCApplication.Models
{
    public class Product //This is my database focused class.
    {
        public int ProductID { get; set; }
        [Required]
        public string UserId { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Provide a Name")]
        [MinLength(3, ErrorMessage = "Product Name has to be at least 3 letters")]
        public string Name { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        [Display(Name="Daily amount of Vitamin C (%)")]
        [Range(0,50000)]
        public int VitCDailyAmount { get; set; }
        [Required]
        public string UPC { get; set; }
        [Required]
        public decimal StarRating { get; set; }
        public AvoidScurvyIdentityUser User { get; set; }
        public ICollection<ProductViewing> ProductViewings { get; set; }
    }
}
