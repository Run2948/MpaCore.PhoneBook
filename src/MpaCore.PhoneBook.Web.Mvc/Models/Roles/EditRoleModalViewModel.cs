using Abp.AutoMapper;
using MpaCore.PhoneBook.Roles.Dto;
using MpaCore.PhoneBook.Web.Models.Common;

namespace MpaCore.PhoneBook.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
