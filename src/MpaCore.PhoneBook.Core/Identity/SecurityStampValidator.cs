using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using MpaCore.PhoneBook.Authorization.Roles;
using MpaCore.PhoneBook.Authorization.Users;
using MpaCore.PhoneBook.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace MpaCore.PhoneBook.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
