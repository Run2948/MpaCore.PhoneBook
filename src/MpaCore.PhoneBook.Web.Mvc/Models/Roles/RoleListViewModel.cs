using System.Collections.Generic;
using MpaCore.PhoneBook.Roles.Dto;

namespace MpaCore.PhoneBook.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
