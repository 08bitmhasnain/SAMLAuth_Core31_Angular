using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using SAMLAuthenticationSample.EntityFrameworkCore.Seed;

namespace SAMLAuthenticationSample.EntityFrameworkCore
{
    [DependsOn(
        typeof(SAMLAuthenticationSampleCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class SAMLAuthenticationSampleEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<SAMLAuthenticationSampleDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        SAMLAuthenticationSampleDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        SAMLAuthenticationSampleDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SAMLAuthenticationSampleEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
