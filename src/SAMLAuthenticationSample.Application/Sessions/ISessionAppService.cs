using System.Threading.Tasks;
using Abp.Application.Services;
using SAMLAuthenticationSample.Sessions.Dto;

namespace SAMLAuthenticationSample.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
