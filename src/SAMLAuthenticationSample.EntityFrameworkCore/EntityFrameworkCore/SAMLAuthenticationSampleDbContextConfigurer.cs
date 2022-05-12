using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SAMLAuthenticationSample.EntityFrameworkCore
{
    public static class SAMLAuthenticationSampleDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SAMLAuthenticationSampleDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SAMLAuthenticationSampleDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
