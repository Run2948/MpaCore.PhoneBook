using System.Threading.Tasks;
using Abp.Application.Services;
using MpaCore.PhoneBook.Sessions.Dto;

namespace MpaCore.PhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
