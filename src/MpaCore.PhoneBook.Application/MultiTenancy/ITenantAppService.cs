using Abp.Application.Services;
using MpaCore.PhoneBook.MultiTenancy.Dto;

namespace MpaCore.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

