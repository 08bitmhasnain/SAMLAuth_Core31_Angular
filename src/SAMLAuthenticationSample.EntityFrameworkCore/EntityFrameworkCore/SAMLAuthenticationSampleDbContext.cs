using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SAMLAuthenticationSample.Authorization.Roles;
using SAMLAuthenticationSample.Authorization.Users;
using SAMLAuthenticationSample.MultiTenancy;

namespace SAMLAuthenticationSample.EntityFrameworkCore
{
    public class SAMLAuthenticationSampleDbContext : AbpZeroDbContext<Tenant, Role, User, SAMLAuthenticationSampleDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SAMLAuthenticationSampleDbContext(DbContextOptions<SAMLAuthenticationSampleDbContext> options)
            : base(options)
        {
        }
    }
}
