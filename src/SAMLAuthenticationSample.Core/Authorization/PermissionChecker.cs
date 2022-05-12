using Abp.Authorization;
using SAMLAuthenticationSample.Authorization.Roles;
using SAMLAuthenticationSample.Authorization.Users;

namespace SAMLAuthenticationSample.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
