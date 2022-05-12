using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SAMLAuthenticationSample.Controllers
{
    public abstract class SAMLAuthenticationSampleControllerBase: AbpController
    {
        protected SAMLAuthenticationSampleControllerBase()
        {
            LocalizationSourceName = SAMLAuthenticationSampleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
