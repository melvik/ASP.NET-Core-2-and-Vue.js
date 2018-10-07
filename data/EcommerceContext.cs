using be_master_with_core2.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be_master_with_core2.Data
{
    public class EcommerceContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        { }
    }
}