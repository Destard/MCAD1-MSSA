using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AvoidScurvyMVCApplication.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name="Product Name")]
        [Required(ErrorMessage ="Please Provide a Name")]
        [MinLength(3, ErrorMessage ="Product Name has to be at least 3 letters")]
        public string UserId { get; set; }
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
        public virtual AvoidScurvyIdentityUser User { get; set; }
        //public virtual ICollection<ProductViewing> ProductViewings { get; set; }
    }
}
