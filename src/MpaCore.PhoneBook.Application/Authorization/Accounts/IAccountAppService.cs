using System.Threading.Tasks;
using Abp.Application.Services;
using MpaCore.PhoneBook.Authorization.Accounts.Dto;

namespace MpaCore.PhoneBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
