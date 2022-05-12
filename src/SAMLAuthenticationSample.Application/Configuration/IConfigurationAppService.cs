using System.Threading.Tasks;
using SAMLAuthenticationSample.Configuration.Dto;

namespace SAMLAuthenticationSample.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
