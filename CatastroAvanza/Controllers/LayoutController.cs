using CatastroAvanza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class LayoutController : BaseController
    {
        [Authorize]
        public ActionResult Sidebar()
        {            
            string role = GetUserRole();
            GeneralConfigurations generalConfigurations = GetConfig(1);
            SidebarUserLevel sidebarUserLevel = generalConfigurations.menus.Where(w => w.role.Equals(role, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            List<SidebarItem> SidebarItemList = sidebarUserLevel.links;

            return PartialView(SidebarItemList);
        }

        [Authorize]
        public ActionResult Navbar()
        {
            var userName = HttpContext.User;
            ViewBag.FullName = userName.Identity.Name;// 
            ViewBag.IdU = userName.Identity.Name;

            return PartialView();
        }
    }
}