using System.ComponentModel.DataAnnotations;

namespace AvoidScurvyMVCApplication.Models
{
    public class ProductViewing
    {
        public int ProductViewingId { get; set; }
        [Required]
        [Display(Name ="Product ID")]
        public int ProductId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Viewing Time")]
        public DateTime ViewingTime { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        [Required]
        [Range(0,10000)]
        [Display(Name = "Price Per Serving")]
        public decimal PricePerServing { get; set; }
        //public virtual Product Product { get; set; }
    }
}
