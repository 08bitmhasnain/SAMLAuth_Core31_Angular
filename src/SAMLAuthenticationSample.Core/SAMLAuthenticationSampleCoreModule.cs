using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using SAMLAuthenticationSample.Authorization.Roles;
using SAMLAuthenticationSample.Authorization.Users;
using SAMLAuthenticationSample.Configuration;
using SAMLAuthenticationSample.Localization;
using SAMLAuthenticationSample.MultiTenancy;
using SAMLAuthenticationSample.Timing;

namespace SAMLAuthenticationSample
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class SAMLAuthenticationSampleCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            SAMLAuthenticationSampleLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = SAMLAuthenticationSampleConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SAMLAuthenticationSampleCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
