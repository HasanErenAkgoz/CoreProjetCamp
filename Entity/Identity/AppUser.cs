using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entity.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }

    }
}
