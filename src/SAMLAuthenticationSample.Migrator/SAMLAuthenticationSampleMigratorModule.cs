using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SAMLAuthenticationSample.Configuration;
using SAMLAuthenticationSample.EntityFrameworkCore;
using SAMLAuthenticationSample.Migrator.DependencyInjection;

namespace SAMLAuthenticationSample.Migrator
{
    [DependsOn(typeof(SAMLAuthenticationSampleEntityFrameworkModule))]
    public class SAMLAuthenticationSampleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SAMLAuthenticationSampleMigratorModule(SAMLAuthenticationSampleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(SAMLAuthenticationSampleMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                SAMLAuthenticationSampleConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SAMLAuthenticationSampleMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
