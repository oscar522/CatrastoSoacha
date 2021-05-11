using CatastroAvanza.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class BaseController : Controller
    {
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