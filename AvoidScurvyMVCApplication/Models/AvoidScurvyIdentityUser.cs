using Microsoft.AspNetCore.Identity;

namespace AvoidScurvyMVCApplication.Models
{
    public class AvoidScurvyIdentityUser : IdentityUser
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
