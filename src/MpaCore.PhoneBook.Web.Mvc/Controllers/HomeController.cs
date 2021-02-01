using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MpaCore.PhoneBook.Controllers;

namespace MpaCore.PhoneBook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PhoneBookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
