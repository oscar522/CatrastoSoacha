using CatastroAvanza.Constantes;
using CatastroAvanza.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class BaseController : Controller
    {

        public string GetUserRole()
        {
            var claims = (System.Security.Claims.ClaimsPrincipal)HttpContext.User;

            string role = claims.Claims.Where(m => m.Type == ClaimsConstants.RoleClaim).FirstOrDefault().Value;

            return role;
        }

        public string GetUserName() => HttpContext.User.Identity.Name;

        public bool UserIsInRol(string rol) => HttpContext.User.IsInRole(rol);


        public GeneralConfigurations GetConfig(int id)
        {
            GeneralConfigurations generalConfigurations = new GeneralConfigurations();
            string TypeSidebar = "";

            TypeSidebar = "~/config.json";

            using (StreamReader r = new StreamReader(Server.MapPath(TypeSidebar)))
            {
                string json = r.ReadToEnd();
                generalConfigurations = JsonConvert.DeserializeObject<GeneralConfigurations>(json);
            }

            return generalConfigurations;
        }
    }
}