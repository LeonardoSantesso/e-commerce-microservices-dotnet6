using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class IdentityServerContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityServerContext(DbContextOptions<IdentityServerContext> options) 
            : base(options) { }
    }
}
