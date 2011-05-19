using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xEasyApp.Core.JsonEntities;
using System.Web.Script.Serialization;
using System.Text;
using xEasyApp.Core.Extensions;
namespace xEasyApp.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public JavaScriptResult Menu()
        {
            List<JsonTreeNode> list = this.GetMenu();
            JavaScriptSerializer s = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            s.Serialize(list, sb);
            sb.Insert(0, "var menudata=");
            return JavaScript(sb.ToString());
        }

      
    }
}
