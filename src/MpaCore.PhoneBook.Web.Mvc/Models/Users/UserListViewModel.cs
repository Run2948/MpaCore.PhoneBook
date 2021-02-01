using System.Collections.Generic;
using MpaCore.PhoneBook.Roles.Dto;

namespace MpaCore.PhoneBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
