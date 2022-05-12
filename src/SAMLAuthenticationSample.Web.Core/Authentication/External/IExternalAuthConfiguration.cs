using System.Collections.Generic;

namespace SAMLAuthenticationSample.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
