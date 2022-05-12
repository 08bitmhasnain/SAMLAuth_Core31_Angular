using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SAMLAuthenticationSample.EntityFrameworkCore;
using SAMLAuthenticationSample.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SAMLAuthenticationSample.Web.Tests
{
    [DependsOn(
        typeof(SAMLAuthenticationSampleWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SAMLAuthenticationSampleWebTestModule : AbpModule
    {
        public SAMLAuthenticationSampleWebTestModule(SAMLAuthenticationSampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SAMLAuthenticationSampleWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SAMLAuthenticationSampleWebMvcModule).Assembly);
        }
    }
}