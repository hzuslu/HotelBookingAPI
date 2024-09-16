using Microsoft.AspNetCore.Identity;

namespace Otel.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public String Name { get; set; }

        public String LastName { get; set; }

        public String City { get; set; }


    }

}