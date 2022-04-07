using Microsoft.AspNetCore.Identity;

namespace AvoidScurvyMVCApplication.Models
{
    public class AvoidScurvyIdentityUser : IdentityUser
    {
        public ICollection<Product> Products { get; set; }
    }
}
