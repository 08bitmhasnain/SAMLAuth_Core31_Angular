using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SAMLAuthenticationSample.Configuration.Dto;

namespace SAMLAuthenticationSample.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SAMLAuthenticationSampleAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
