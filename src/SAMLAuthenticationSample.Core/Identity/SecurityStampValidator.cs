using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using SAMLAuthenticationSample.Authorization.Roles;
using SAMLAuthenticationSample.Authorization.Users;
using SAMLAuthenticationSample.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace SAMLAuthenticationSample.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
