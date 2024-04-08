using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Policy_API.Context
{
    public class PolicyIdentityContext : IdentityDbContext
    {
        public PolicyIdentityContext(DbContextOptions<PolicyIdentityContext> dbContextOptions) : base(dbContextOptions)
        { 
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
