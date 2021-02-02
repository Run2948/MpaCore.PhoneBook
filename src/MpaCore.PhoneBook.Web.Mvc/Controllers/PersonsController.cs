using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using MpaCore.PhoneBook.Authorization;
using MpaCore.PhoneBook.Controllers;
using MpaCore.PhoneBook.Persons;
using MpaCore.PhoneBook.Web.Models.Users;

namespace MpaCore.PhoneBook.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Persons)]
    public class PersonsController : PhoneBookControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonsController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int personId)
        {
            var user = await _personAppService.GetPersonForEditAsync(new NullableIdDto<int>(personId));
            return PartialView("_EditModal", user);
        }
    }
}