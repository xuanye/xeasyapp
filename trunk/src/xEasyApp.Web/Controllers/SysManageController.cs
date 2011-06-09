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
using xEasyApp.Core.Exceptions;
using xEasyApp.Core.Configurations;
using xEasyApp.Web.Models;

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
            string strparentId = form["ParentID"];
            int? parentId =null;
            if (!string.IsNullOrEmpty(strparentId))
            {
                parentId = Convert.ToInt32(strparentId);
            }
            if (string.IsNullOrEmpty(colkey))
            {
                throw new ArgumentNullException("colkey", "主键表示没有传递，请在前台js中配置");
            }
            if (string.IsNullOrEmpty(colsinfo))
            {
                throw new ArgumentNullException("colsinfo", "列信息不能为空，请在前台js中配置");
            }
            List<RoleInfo> list = sysManageService.QueryRoleList(parentId,base.UserId);
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));           
            return Json(data);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RoleTreeList(FormCollection form)
        {
            List<JsonTreeNode> nodes = new List<JsonTreeNode>();
            string strparentId = form["id"];// ?? "0";
            int? parentId = null;
            if (!string.IsNullOrEmpty(strparentId))
            {
                parentId = Convert.ToInt32(strparentId);
              
            }
            var list = sysManageService.GetRoles(parentId, base.UserId);
            foreach (var item in list)
            {
                JsonTreeNode cnode = new JsonTreeNode();
                cnode.id = item.RoleID.ToString();
                cnode.text = item.RoleName;
                cnode.value = item.RoleCode;
                cnode.hasChildren = item.HasChild;
                cnode.classes = item.IsSystem ? "system" : "normal";
                nodes.Add(cnode);
            }
            return Json(nodes);
        }
        public ActionResult EditRole(int? id,int? ParentID,string ParentName)
        {
            RoleInfo ri;
            if (id.HasValue)
            {
                ri = sysManageService.GetRoleInfo(id.Value);
                if (ri == null)
                {
                    throw new ArgumentException("参数错误，不存在对应的角色", "RoleID");
                }
                else
                {
                    if (ri.IsSystem)
                    {
                        throw new NoPermissionExecption("您无法编辑系统角色");
                    }
                }
            }
            else
            {
                ri = new RoleInfo();
                if (ParentID.HasValue)
                {
                    ri.ParentID = ParentID;
                    ri.ParentName = ParentName;
                }
                else
                {
                    ri.ParentName = "根角色";
                }
            }
            return View(ri);
        }
        public ContentResult ValidRoleCode(string RoleCode)
        {
            bool isValid = sysManageService.ValidRoleCode(RoleCode);
            return Content(isValid ? "true" : "false","application/json");
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult SaveRoleInfo(int? id,RoleInfo ri)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if(id.HasValue && id.Value>0)
                {
                     ri.IsNew =false;
                     ri.RoleID = id.Value;
                }
                else
                {
                    ri.IsNew = true;
                }               
                
                ri.LastUpdateUserUID = base.UserId;
                ri.LastUpdateUserName = base.CurrentUser.FullName;
                ri.LastUpdateTime = DateTime.Now;
                ri.IsSystem = false;
                sysManageService.SaveRoleInfo(ri);
                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException ex)
            {
                msg.IsSuccess = false;
                msg.Msg =ex.Message;
            }     
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败："+ex.Message;
            }            
            return Json(msg);
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public JsonResult DeleteRoleInfo(int id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            
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

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteDeptInfo(string id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int ret = sysManageService.DeleteDeptInfo(id);
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
                catch (BizException bizex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = bizex.Message;
                }
                catch //(Exception ex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = "操作失败,请稍后重试！";
                }
            }
            else
            {
                msg.IsSuccess = false;
                msg.Msg = "参数错误";
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

        public JsonResult QueryDeptTree(string ExtId, FormCollection form)
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
                        if (item.DeptCode == ExtId)
                        {
                            continue;
                        }
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
                    if (item.DeptCode == ExtId)
                    {
                        continue;
                    }
                    JsonTreeNode cnode = new JsonTreeNode();
                    cnode.id = item.DeptCode;
                    cnode.text = item.DeptName;
                    cnode.value = item.DeptCode;
                    nodes.Add(cnode);
                }
            }
            return Json(nodes);
        }
       #endregion

       #region 用户管理
        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult EditUser(string id,string deptCode,string deptName)
        {
            UserInfo u = null;
            if (!string.IsNullOrEmpty(id))
            {
                u = sysManageService.GetUserInfo(id);
                if (u == null)
                {
                    throw new ArgumentException("参数错误", "id");
                }
            }
            else
            {
                u = new UserInfo();
                u.DeptCode = deptCode;
                u.DeptName = deptName;
                if (u.DeptCode == AppConfig.RootDeptCode)
                {
                    u.DeptName = AppConfig.RootDeptName;
                }
               
            }
            return View(u);
        }

        public ContentResult ValidUserUID(string UserUID)
        {
            bool isValid = sysManageService.ValidUserUID(UserUID);
            return Content(isValid ? "true" : "false", "application/json");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteUserInfo(string id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int ret = sysManageService.DeleteUserInfo(id);
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
                catch (BizException bizex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = bizex.Message;
                }
                catch //(Exception ex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = "操作失败,请稍后重试！";
                }
            }
            else
            {
                msg.IsSuccess = false;
                msg.Msg = "参数错误";
            }
            return Json(msg);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveUserInfo(string id, UserInfo user)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                user.IsNew = string.IsNullOrEmpty(id);

                user.LastUpdateUserUID = base.UserId;
                user.LastUpdateUserName = base.CurrentUser.FullName;
                user.LastUpdateTime = DateTime.Now;

                sysManageService.SaveUserInfo(user);
                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException ex)
            {
                msg.IsSuccess = false;
                msg.Msg = ex.Message;
            }
            catch
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败,请稍后重试！";
            }
            return Json(msg);
        }

        public ActionResult SetDept(int mode,string extid)
        {
            SetDeptViewModel model = new SetDeptViewModel();
            model.IsMuliSelect = mode == 1;
            model.Url = Url.Action("QueryDeptTree", new{ ExtId=extid });
            return View(model);
        }
       #endregion

       #region 权限管理
        public ActionResult PrivilegeList()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PrivilegeList(FormCollection form)
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
            if (parentCode == "-1")
            {
                parentCode = null ;
            }
            List<Privilege> list = sysManageService.QueryPrivilegeListByParentCode(parentCode);        
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));
            return Json(data);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PrivilegeTreeList(FormCollection form)
        {
            var nodes = new List<JsonTreeNode>();
            string parentId = form["id"];// ?? "0";
    
            List<Privilege> list = sysManageService.GetChildPrivileges(parentId);
            if (list != null)
            {               
                foreach (var item in list)
                {
                    JsonTreeNode node = new JsonTreeNode();
                    node.id = item.PrivilegeCode;
                    node.text = item.PrivilegeName;
                    node.value = item.Uri;
                    node.hasChildren = item.HasChild;
                    nodes.Add(node);
                }
                if (parentId == null && nodes.Count>0 && nodes[0].hasChildren) //如果是根
                {
                    List<Privilege> clist = sysManageService.GetChildPrivileges(nodes[0].id);
                    nodes[0].complete = true;
                    nodes[0].isexpand = true;
                    if (clist != null)
                    {
                        foreach (var citem in clist)
                        {
                            JsonTreeNode cnode = new JsonTreeNode();
                            cnode.id = citem.PrivilegeCode;
                            cnode.text = citem.PrivilegeName;
                            cnode.value = citem.Uri;
                            cnode.hasChildren = citem.HasChild;
                            nodes[0].ChildNodes.Add(cnode);
                        }
                    }
                }
            }           
            return Json(nodes);
        }

        /// <summary>
        /// Edits the privilege.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="parentCode">The parent code.</param>
        /// <param name="parentName">Name of the parent.</param>
        /// <returns></returns>
        public ActionResult EditPrivilege(string id,string parentCode,string parentName)
        {
            Privilege p = null;
            if (string.IsNullOrEmpty(id))
            {
                p = new Privilege();
                if (string.IsNullOrEmpty(parentCode))
                {
                    p.ParentName = "根权限";
                }
                else
                {
                    p.ParentID = parentCode;
                    p.ParentName = parentName;
                }
            }
            else
            {
                p = sysManageService.GetPrivilege(id);
                if (p == null)
                {
                    throw new ArgumentException("参数错误", "Privilege");
                }
            }
            return View(p);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeletePrivilegeInfo(string id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int ret = sysManageService.DeletePrivilege(id);
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
                catch (BizException bizex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = bizex.Message;
                }
                catch //(Exception ex)
                {
                    msg.IsSuccess = false;
                    msg.Msg = "操作失败,请稍后重试！";
                }
            }
            else
            {
                msg.IsSuccess = false;
                msg.Msg = "参数错误";
            }
            return Json(msg);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SavePrivilegeInfo(string id,Privilege p)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    p.IsNew = true;
                }
                else
                {
                    p.IsNew = false;
                }
                //在根下新建权限
                if (p.PrivilegeCode == "")
                {
                    p.PrivilegeCode = null;
                }
                p.LastUpdateUserUID = base.UserId;
                p.LastUpdateUserName = base.CurrentUser.FullName;
                p.LastUpdateTime = DateTime.Now;

                sysManageService.SavePrivilege(p);

                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException bizex)
            {
                msg.IsSuccess = false;
                msg.Msg = bizex.Message;
            }
            catch
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败,请稍后重试";
            }
            return Json(msg);
        }

        public ContentResult ValidPrivilegeCode(string PrivilegeCode)
        {
            bool isValid = sysManageService.ValidPrivilegeCode(PrivilegeCode);
            return Content(isValid ? "true" : "false", "application/json");
        }
       #endregion
    }
}
