using System.Collections.Generic;
using MpaCore.PhoneBook.Roles.Dto;

namespace MpaCore.PhoneBook.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}