using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xEasyApp.Core.BaseClass;
using xEasyApp.Core.JsonEntities;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Entities;

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

       #region 角色管理
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
            RoleInfo ri;
            if (!string.IsNullOrEmpty(id))
            {
                ri = sysManageService.GetRoleInfo(id);
                if (ri == null)
                {
                    throw new Exception("参数错误，不存在对应的角色");
                }
            }
            else
            {
                ri = new RoleInfo();
            }
            return View(ri);
        }
        public ContentResult ValidRoleCode(string RoleCode)
        {
            bool isValid = sysManageService.ValidRoleCode(RoleCode);
            return Content(isValid ? "true" : "false","application/json");
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult SaveRoleInfo(string id,RoleInfo ri)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ri.IsNew = true;
                }
                else
                {
                    ri.IsNew = false;
                }
                ri.LastUpdateUserUID = base.UserId;
                ri.LastUpdateUserName = base.CurrentUser.FullName;
                ri.LastUpdateTime = DateTime.Now;
                ri.IsSystem = false;
                sysManageService.SaveRoleInfo(ri);
                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败："+ex.Message;
            }            
            return Json(msg);
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult DeleteRoleInfo(string id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int ret = sysManageService.DeleteRoleInfo(id);
                    if (ret > 0)
                    {
                        msg.IsSuccess = true;
                        msg.Msg = "操作成功";
                    }
                    else
                    {
                        msg.IsSuccess = false;
                        msg.Msg = "操作失败:操作完成了,但是莫有效果";
                    }
                }
                catch (Exception ex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = "操作失败:" + ex.Message;
                }
            }
            else
            {
                msg.IsSuccess = false;
                msg.Msg = "参数错误";
            }
            return Json(msg);
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
        #endregion

       #region 部门管理
        public ActionResult DeptInfoList()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeptInfoList(FormCollection form)
        {
            string parentCode = form["parentCode"];
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
            if (string.IsNullOrEmpty(parentCode) || parentCode == "-1")
            {
              Department root =  sysManageService.GetRootDepartment();
              parentCode = root.DeptCode;
            }
            List<Department> list = sysManageService.GetChildDeptsByParentCode(parentCode);
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));
            return Json(data);
        }

        public ActionResult EditDept(string id,string parentCode,string parentName)
        {
            Department dept;
            if (!string.IsNullOrEmpty(id))
            {
                dept = sysManageService.GetDeptInfo(id);
                if (dept == null)
                {
                    throw new Exception("参数错误，不存在对应的角色");
                }
            }
            else
            {
                dept = new Department();
                if (parentCode == "-1")
                {
                    Department root = sysManageService.GetRootDepartment();
                    dept.ParentCode = root.DeptName;
                    dept.ParentName = root.DeptName;
                }
                else
                {
                    dept.ParentCode = parentCode;
                    dept.ParentName = parentName;
                }
            }
            return View(dept);
            
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult DeptInfoTreeList(FormCollection form)
        {
            var nodes = new List<JsonTreeNode>();
            string parentId = form["id"];// ?? "0";
            if (string.IsNullOrEmpty(parentId))
            {              
                Department root = sysManageService.GetRootDepartment();
                JsonTreeNode node = new JsonTreeNode();
                node.id = root.DeptCode;
                node.text = root.DeptName;
                node.value = root.DeptCode;  
                node.isexpand = true;
                node.complete = true;
                var clist = sysManageService.GetChildDeptsByParentCode(root.DeptCode);
                if (clist != null)
                {
                    node.hasChildren = true;
                    foreach (var item in clist)
                    {
                        JsonTreeNode cnode = new JsonTreeNode();
                        cnode.id = item.DeptCode;
                        cnode.text = item.DeptName;
                        cnode.value = item.DeptCode; 
                        node.ChildNodes.Add(cnode);
                    }
                }
                nodes.Add(node);
            }
            else
            {
                var list = sysManageService.GetChildDeptsByParentCode(parentId);
                foreach (var item in list)
                {
                    JsonTreeNode cnode = new JsonTreeNode();
                    cnode.id = item.DeptCode;
                    cnode.text = item.DeptName;
                    cnode.value = item.DeptCode;
                    nodes.Add(cnode);
                }
            }
            return Json(nodes);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveDeptInfo(string id,Department department)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    department.IsNew = true;
                }
                else
                {
                    department.IsNew = false;
                }
                
                department.LastUpdateUserUID = base.UserId;
                department.LastUpdateUserName = base.CurrentUser.FullName;
                department.LastUpdateTime = DateTime.Now;

                sysManageService.SaveDeptInfo(department);

                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }


        public ContentResult ValidDeptCode(string DeptCode)
        {
            bool isValid = sysManageService.ValidDeptCode(DeptCode);
            return Content(isValid ? "true" : "false", "application/json");
        }


        public ActionResult DeptUserList(string DeptCode,string DeptName)
        {
            ViewData["DeptCode"] = DeptCode;
            ViewData["DeptName"] = DeptName;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeptUserList(string DeptCode, FormCollection form)
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
            int pageIndex = Convert.ToInt32(form["page"]);
            int pageSize = Convert.ToInt32(form["rp"]);
            PageView view = new PageView();
            view.PageIndex = pageIndex - 1;
            view.PageSize = pageSize;

            PagedList<UserInfo> pageList = sysManageService.QueryDeptUserList(view, DeptCode);
            var data = JsonFlexiGridData.ConvertFromPagedList(pageList, colkey, colsinfo.Split(','));
            return Json(data);
        }
       #endregion
    }
}
