using System;
using Microsoft.AspNetCore.Identity;

namespace SkyHigh.Domain
{
    public class SkyHighUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
