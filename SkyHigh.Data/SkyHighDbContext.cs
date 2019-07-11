using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Domain;

namespace SkyHigh.Data
{
    public class SkyHighDbContext : IdentityDbContext<SkyHighUser, IdentityRole, string>
    {
        public SkyHighDbContext(DbContextOptions<SkyHighDbContext> options)
            : base(options)
        {
        }
    }
}
