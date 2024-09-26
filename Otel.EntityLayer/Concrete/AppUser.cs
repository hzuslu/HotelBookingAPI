using Microsoft.AspNetCore.Identity;

namespace Otel.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

    }

}