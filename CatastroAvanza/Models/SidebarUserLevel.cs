using System.Collections.Generic;

namespace CatastroAvanza.Models
{
    public class SidebarUserLevel
    {
        public string role { get; set; }
        public List<SidebarItem> links { get; set; }
    }
}