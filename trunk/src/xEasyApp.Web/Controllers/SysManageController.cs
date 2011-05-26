using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xEasyApp.Core.BaseClass;
using xEasyApp.Core.JsonEntities;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;

namespace xEasyApp.Web.Controllers
{
    // [Authorize()]
    public class SysManageController : MyControllerBase
    {
        public SysManageController(ISysManageService sysservice)
        {
            sysManageService = sysservice;
        }

        private ISysManageService sysManageService;
        public ActionResult RoleInfoList()
        {
            return View();
        }

        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult RoleInfoList(FormCollection form)
        {
            string colkey = form["colkey"];
            string colsinfo = form["colsinfo"];
            if (string.IsNullOrEmpty(colkey))
            {
                throw new ArgumentNullException("colkey", "主键表示没有传递，请在前台js中配置");
            }
            if (string.IsNullOrEmpty(colsinfo))
            {
                throw new ArgumentNullException("colsinfo", "列信息不能为空，请在前台js中配置");
            }
            List<RoleInfo> list = sysManageService.QueryRoleList();
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));           
            return Json(data);
        }

        public ActionResult EditRole(string id)
        {
            RoleInfo ri = new RoleInfo();
            if (string.IsNullOrEmpty(id))
            { 
                
            }
            return View(ri);
        }
        public ActionResult RoleUserRelationList(string id)
        {
            return View();
        }
        public ActionResult SetRoleUser(string id)
        {
            return View();
        }
        public ActionResult SetRoleRight(string id)
        {
            return View();
        }
    }
}
