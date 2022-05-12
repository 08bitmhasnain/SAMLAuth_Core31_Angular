using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SAMLAuthenticationSample.Configuration;

namespace SAMLAuthenticationSample.Web.Host.Startup
{
    [DependsOn(
       typeof(SAMLAuthenticationSampleWebCoreModule))]
    public class SAMLAuthenticationSampleWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SAMLAuthenticationSampleWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SAMLAuthenticationSampleWebHostModule).GetAssembly());
        }
    }
}
