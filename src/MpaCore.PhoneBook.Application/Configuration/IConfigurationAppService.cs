using System.Threading.Tasks;
using MpaCore.PhoneBook.Configuration.Dto;

namespace MpaCore.PhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
