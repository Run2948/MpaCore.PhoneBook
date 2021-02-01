using System.Collections.Generic;

namespace MpaCore.PhoneBook.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
