using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xEasyApp.Core.JsonEntities;
using System.Web.Script.Serialization;
using System.Text;
using xEasyApp.Core.Extensions;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.BaseClass;
using xEasyApp.Core.Configurations;
using xEasyApp.Core.Exceptions;
using System.Web.Security;
using xEasyApp.Web.Models;

namespace xEasyApp.Web.Controllers
{
    [HandleError]
    public class HomeController : MyControllerBase
    {
        public HomeController(ISysManageService service)
        {
            _SysManageService = service;
        }
        private ISysManageService _SysManageService;

        public ActionResult Login(string ReturnUrl)
        {
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                ViewData["RedirectUrl"] = Url.Action("Index");
            }
            else
            {
                ViewData["RedirectUrl"] = ReturnUrl;
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public JsonResult Authentication(FormCollection form)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                string userid = form["UserID"];
                string pwd = form["Password"];


                bool IsSuccess = _SysManageService.Authentication(userid, pwd);
                if (IsSuccess)
                {
                    FormsAuthentication.SetAuthCookie(userid, false);
                    msg.IsSuccess = true;
                    msg.Msg = "操作成功";
                }
                else
                {
                    msg.IsSuccess = false;
                    msg.Msg = "用户名或密码错误";
                }
            }
            catch (BizException bizex)
            {
                msg.IsSuccess = false;
                msg.Msg = bizex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "登录失败：" + ex.Message;
            }
            return Json(msg);
        }

        [xEasyAppAuthorize()]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            model.UserID = base.UserId;
            model.UserFullName = base.CurrentUser.FullName;
            model.LogoTitle = AppConfig.LogoTitle;
            return View(model);
        }


        [xEasyAppAuthorize()]
        public JavaScriptResult XmlMenu()
        {
            List<JsonTreeNode> list = this.GetXmlMenu();
            JavaScriptSerializer s = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            s.Serialize(list, sb);
            sb.Insert(0, "var menudata=");
            return JavaScript(sb.ToString());
        }
        [xEasyAppAuthorize()]
        public JavaScriptResult Menu()
        {
            List<Privilege> menus = _SysManageService.GetAllMenu();
            List<string> usermenuids = _SysManageService.GetUserMenuIds(base.UserId);

            List<Privilege> topmenus = menus.FindAll(x => string.IsNullOrEmpty(x.ParentID));
            List<JsonTreeNode> list = BuildTreeNode(menus, topmenus, usermenuids);

            JavaScriptSerializer s = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            s.Serialize(list, sb);
            sb.Insert(0, "var menudata=");
            return JavaScript(sb.ToString());
        }

        private List<JsonTreeNode> BuildTreeNode(List<Privilege> allmenus, List<Privilege> menus, List<string> usermenuids)
        {
            List<JsonTreeNode> treenodelist = new List<JsonTreeNode>();
            bool isSupperAdmin = base.IsInRole(AppConfig.SuperAdminRoleCode);
            foreach (Privilege p in menus)
            {
                if (isSupperAdmin || usermenuids.Contains(p.PrivilegeCode))
                {
                    JsonTreeNode treenode = new JsonTreeNode();
                    treenode.id = p.PrivilegeCode;
                    treenode.text = p.PrivilegeName;

                    treenode.value = GetTruePath(p.Uri);
                    treenode.isexpand = false;
                    treenode.showcheck = false;
                    treenode.complete = true;
                    List<Privilege> cmenus = allmenus.FindAll(x => x.ParentID == p.PrivilegeCode);
                    if (cmenus != null && cmenus.Count > 0)
                    {
                        treenode.ChildNodes.AddRange(BuildTreeNode(allmenus, cmenus, usermenuids));
                        if (treenode.ChildNodes.Count > 0)
                        {
                            treenode.isexpand = true;
                            treenode.hasChildren = true;
                        }
                    }
                    treenodelist.Add(treenode);
                }

            }
            return treenodelist;
        }

        private string GetTruePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (path.ToLower().StartsWith("http://") || path.ToLower().StartsWith("https://"))
                {
                    return path;
                }
                if (path.StartsWith("~/"))
                {
                    return Url.Content(path);

                }
                return path;
            }
            return "";
        }
    }
}
