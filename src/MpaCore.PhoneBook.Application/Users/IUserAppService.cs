using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MpaCore.PhoneBook.Roles.Dto;
using MpaCore.PhoneBook.Users.Dto;

namespace MpaCore.PhoneBook.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
