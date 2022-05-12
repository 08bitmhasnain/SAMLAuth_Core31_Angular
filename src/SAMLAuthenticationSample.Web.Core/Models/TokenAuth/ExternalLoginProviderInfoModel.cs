using Abp.AutoMapper;
using SAMLAuthenticationSample.Authentication.External;

namespace SAMLAuthenticationSample.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
