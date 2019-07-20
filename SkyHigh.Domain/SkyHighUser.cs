using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SkyHigh.Domain
{
    public class SkyHighUser : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
