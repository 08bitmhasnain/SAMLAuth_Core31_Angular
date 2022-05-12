using Abp.Application.Services;
using SAMLAuthenticationSample.MultiTenancy.Dto;

namespace SAMLAuthenticationSample.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

