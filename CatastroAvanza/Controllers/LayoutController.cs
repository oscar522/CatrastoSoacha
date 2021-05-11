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
            string role = "Administrator";
            GeneralConfigurations generalConfigurations = GetConfig(1);
            SidebarUserLevel sidebarUserLevel = generalConfigurations.menus.Where(w => w.role.Equals(role, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            List<SidebarItem> SidebarItemList = sidebarUserLevel.links;

            return PartialView(SidebarItemList);
        }

        [Authorize]
        public ActionResult Navbar()
        {
            //ViewBag.FullName = GetTokenObject().FullName;// 
            ViewBag.FullName = "Oscar Ballesteros";// 
            //ViewBag.IdU = GetTokenObject().FullName;
            ViewBag.IdU = "Oscar Ballesteros";

            return PartialView();
        }
    }
}