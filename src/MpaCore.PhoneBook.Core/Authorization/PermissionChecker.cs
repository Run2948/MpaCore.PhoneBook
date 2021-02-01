using Abp.Authorization;
using MpaCore.PhoneBook.Authorization.Roles;
using MpaCore.PhoneBook.Authorization.Users;

namespace MpaCore.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
