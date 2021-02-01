using Abp.Application.Services.Dto;

namespace MpaCore.PhoneBook.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

