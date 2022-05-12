using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SAMLAuthenticationSample.Configuration;
using SAMLAuthenticationSample.Web;

namespace SAMLAuthenticationSample.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SAMLAuthenticationSampleDbContextFactory : IDesignTimeDbContextFactory<SAMLAuthenticationSampleDbContext>
    {
        public SAMLAuthenticationSampleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SAMLAuthenticationSampleDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SAMLAuthenticationSampleDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SAMLAuthenticationSampleConsts.ConnectionStringName));

            return new SAMLAuthenticationSampleDbContext(builder.Options);
        }
    }
}
