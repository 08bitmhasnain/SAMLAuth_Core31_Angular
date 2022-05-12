using Abp.Application.Services.Dto;

namespace SAMLAuthenticationSample.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

