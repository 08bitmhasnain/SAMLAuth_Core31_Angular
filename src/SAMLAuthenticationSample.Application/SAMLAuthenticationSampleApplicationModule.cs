using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SAMLAuthenticationSample.Authorization;

namespace SAMLAuthenticationSample
{
    [DependsOn(
        typeof(SAMLAuthenticationSampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SAMLAuthenticationSampleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SAMLAuthenticationSampleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SAMLAuthenticationSampleApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
