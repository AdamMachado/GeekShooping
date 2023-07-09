using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityService.Model.Context
{
    public class ApplicationUser : IdentityUser

    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
    }
}
