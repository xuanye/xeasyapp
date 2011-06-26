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
using xEasyApp.Core;
using StructureMap;
using xEasyApp.Core.Extensions;
using xEasyApp.Core.Common;

namespace xEasyApp.Web.Controllers
{
    [xEasyAppAuthorize()]
    public class SysManageController : MyControllerBase
    {
        public SysManageController(ISysManageService sysservice)
        {
            sysManageService = sysservice;
        }

        private ISysManageService sysManageService;

        #region 角色管理
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_Role_PagePrivilegeCode)]
        public ActionResult RoleInfoList()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RoleInfoList(FormCollection form)
        {
            string colkey = form["colkey"];
            string colsinfo = form["colsinfo"];
            string strparentId = form["ParentID"];
            int? parentId = null;
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
            List<RoleInfo> list = sysManageService.QueryRoleList(parentId, base.UserId);
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
        public ActionResult EditRole(int? id, int? ParentID, string ParentName)
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
            return Content(isValid ? "true" : "false", "application/json");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveRoleInfo(int? id, RoleInfo ri)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    ri.IsNew = false;
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
                msg.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }
        [AcceptVerbs(HttpVerbs.Post)]
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
        public ActionResult RoleUserRelationList(int RoleID)
        {
            ViewData["RoleID"] = RoleID;
            //TODO：验证是否能管理这个角色
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RoleUserRelationList(FormCollection form)
        {
            string colkey = form["colkey"];
            string colsinfo = form["colsinfo"];
            int roleId = Convert.ToInt32(form["RoleID"]);
            //TODO：验证是否能管理这个角色
            string qtext = form["qtext"];
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

            PagedList<UserInfo> pageList = sysManageService.QueryRoletUserList(view, roleId, qtext);
            var data = JsonFlexiGridData.ConvertFromPagedList(pageList, colkey, colsinfo.Split(','));
            return Json(data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteRoleUser(FormCollection form)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                int roleid = Convert.ToInt32(form["RoleID"]);
                //TODO：验证是否能管理这个角色
                string userids = form["userids"];
                sysManageService.DeleteRoleUser(roleid, userids);

                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException bizex)
            {
                msg.IsSuccess = false;
                msg.Msg = bizex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddRoleUser(FormCollection form)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                int roleid = Convert.ToInt32(form["RoleID"]);
                //TODO：验证是否能管理这个角色
                string userids = form["userids"];
                sysManageService.AddRoleUser(roleid, userids, base.UserId, base.CurrentUser.FullName);

                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException bizex)
            {
                msg.IsSuccess = false;
                msg.Msg = bizex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }
        public ActionResult SetRoleUser(string id)
        {
            return View();
        }
        public ActionResult SetRolePrivilege(int RoleID)
        {
            bool ishasright = sysManageService.CheckUserAuthorizationRight(RoleID, base.UserId);
            if (!ishasright)
            {
                throw new NoPermissionExecption("您无权对该角色授权");
            }
            ViewData["RoleID"] = RoleID;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SetRolePrivilege(FormCollection form)
        {
            JsonReturnMessages msg = new JsonReturnMessages();

            try
            {

                int roleid = Convert.ToInt32(form["RoleID"]);
                string addids = form["AddIDS"];
                string minusids = form["MinusIDS"];
                if (string.IsNullOrEmpty(addids) && string.IsNullOrEmpty(minusids))
                {
                    msg.IsSuccess = false;
                    msg.Msg = "没有要操作的项";
                }
                else
                {
                    sysManageService.SetRolePrivilege(roleid, addids, minusids, base.UserId, base.CurrentUser.FullName);
                    msg.IsSuccess = true;
                    msg.Msg = "操作成功";
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
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }

        #endregion

        #region 部门管理
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_Org_PagePrivilegeCode)]
        public ActionResult OrgInfoList()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult OrgInfoList(FormCollection form)
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
                Organization root = sysManageService.GetRootOrganization();
                parentCode = root.OrgCode;
            }
            List<Organization> list = sysManageService.GetChildOrgsByParentCode(parentCode);
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));
            return Json(data);
        }

        public ActionResult EditOrg(string id, string parentCode, string parentName)
        {
            Organization Org;
            if (!string.IsNullOrEmpty(id))
            {
                Org = sysManageService.GetOrgInfo(id);
                if (Org == null)
                {
                    throw new Exception("参数错误，不存在对应的角色");
                }
            }
            else
            {
                Org = new Organization();
                if (parentCode == "-1")
                {
                    Organization root = sysManageService.GetRootOrganization();
                    Org.ParentCode = root.OrgCode;
                    Org.ParentName = root.OrgName;
                    Org.OrgType = 0;
                }
                else
                {
                    Org.ParentCode = parentCode;
                    Org.ParentName = parentName;
                    Org.OrgType = 1;
                }
            }
            return View(Org);

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult OrgInfoTreeList(FormCollection form)
        {
            var nodes = new List<JsonTreeNode>();
            string parentId = form["id"];// ?? "0";
            if (string.IsNullOrEmpty(parentId))
            {
                Organization root = sysManageService.GetRootOrganization();
                JsonTreeNode node = new JsonTreeNode();
                node.id = root.OrgCode;
                node.text = root.OrgName;
                node.value = root.OrgCode;

                node.isexpand = true;
                node.complete = true;

                string rootOrgCode = root.OrgCode;
                var clist = sysManageService.GetChildOrgsByParentCode(rootOrgCode);

                if (clist != null)
                {
                    node.hasChildren = true;
                    foreach (var item in clist)
                    {
                        JsonTreeNode cnode = new JsonTreeNode();
                        cnode.id = item.OrgCode;
                        cnode.text = item.OrgName;
                        cnode.value = item.OrgCode;
                        cnode.hasChildren = item.HasChild;
                        node.ChildNodes.Add(cnode);
                    }
                }
                nodes.Add(node);
            }
            else
            {
                var list = sysManageService.GetChildOrgsByParentCode(parentId);
                foreach (var item in list)
                {
                    JsonTreeNode cnode = new JsonTreeNode();
                    cnode.id = item.OrgCode;
                    cnode.text = item.OrgName;
                    cnode.value = item.OrgCode;
                    cnode.hasChildren = item.HasChild;
                    nodes.Add(cnode);
                }
            }
            return Json(nodes);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveOrgInfo(string id, Organization Organization)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    Organization.IsNew = true;
                }
                else
                {
                    Organization.IsNew = false;
                }

                Organization.LastUpdateUserUID = base.UserId;
                Organization.LastUpdateUserName = base.CurrentUser.FullName;
                Organization.LastUpdateTime = DateTime.Now;

                sysManageService.SaveOrgInfo(Organization);

                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException bizex)
            {
                msg.IsSuccess = false;
                msg.Msg = bizex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteOrgInfo(string id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int ret = sysManageService.DeleteOrgInfo(id);
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
        public ContentResult ValidOrgCode(string OrgCode)
        {
            bool isValid = sysManageService.ValidOrgCode(OrgCode);
            return Content(isValid ? "true" : "false", "application/json");
        }
    
        public ActionResult OrgUserList(string OrgCode, string OrgName)
        {
            ViewData["OrgCode"] = OrgCode;
            ViewData["OrgName"] = OrgName;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult OrgUserList(string OrgCode, FormCollection form)
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

            PagedList<UserInfo> pageList = sysManageService.QueryOrgUserList(view, OrgCode);
            var data = JsonFlexiGridData.ConvertFromPagedList(pageList, colkey, colsinfo.Split(','));
            return Json(data);
        }

        public JsonResult QueryOrgTree(string ExtId, FormCollection form)
        {
            var nodes = new List<JsonTreeNode>();
            string parentId = form["id"];// ?? "0";
            if (string.IsNullOrEmpty(parentId))
            {
                Organization root = sysManageService.GetRootOrganization();
                JsonTreeNode node = new JsonTreeNode();
                node.id = root.OrgCode;
                node.text = root.OrgName;
                node.value = root.OrgCode;
                node.isexpand = true;
                node.complete = true;
                var clist = sysManageService.GetChildOrgsByParentCode(root.OrgCode);
                if (clist != null)
                {
                    node.hasChildren = true;
                    foreach (var item in clist)
                    {
                        if (item.OrgCode == ExtId)
                        {
                            continue;
                        }
                        JsonTreeNode cnode = new JsonTreeNode();
                        cnode.id = item.OrgCode;
                        cnode.text = item.OrgName;
                        cnode.value = item.OrgCode;
                        cnode.hasChildren = item.HasChild;
                        node.ChildNodes.Add(cnode);
                    }
                }
                nodes.Add(node);
            }
            else
            {
                var list = sysManageService.GetChildOrgsByParentCode(parentId);
                foreach (var item in list)
                {
                    if (item.OrgCode == ExtId)
                    {
                        continue;
                    }
                    JsonTreeNode cnode = new JsonTreeNode();
                    cnode.id = item.OrgCode;
                    cnode.text = item.OrgName;
                    cnode.value = item.OrgCode;
                    cnode.hasChildren = item.HasChild;
                    nodes.Add(cnode);
                }
            }
            return Json(nodes);
        }
        #endregion

        #region 用户管理
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_User_PagePrivilegeCode)]
        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult EditUser(string id, string OrgCode, string OrgName)
        {
            UserInfo u = null;
            if (!string.IsNullOrEmpty(id))
            {
                u = sysManageService.GetUserInfo(id);
                if (u == null)
                {
                    throw new ArgumentException("参数错误", "id");
                }
                else
                {
                    u.Password = "";
                }
            }
            else
            {
                u = new UserInfo();
                u.OrgCode = OrgCode;
                u.OrgName = OrgName;
                if (u.OrgCode == AppConfig.RootOrgCode)
                {
                    u.OrgName = AppConfig.RootOrgName;
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

                if (user.IsNew && string.IsNullOrEmpty(user.Password))
                {
                    throw new BizException("新用户密码不能为空");
                }
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

        public ActionResult SetOrg(int mode, string extid)
        {
            SetOrgViewModel model = new SetOrgViewModel();
            model.IsMuliSelect = mode == 1;
            model.Url = Url.Action("QueryOrgTree", new { ExtId = extid });
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult QueryAllUserTree(FormCollection form)
        {
            var nodes = new List<JsonTreeNode>();
            string parentId = form["id"];// ?? "0";
            if (string.IsNullOrEmpty(parentId))
            {
                Organization root = sysManageService.GetRootOrganization();
                JsonTreeNode node = new JsonTreeNode();
                node.id = root.OrgCode;
                node.text = root.OrgName;
                node.classes = "group";
                node.value = "1";
                node.isexpand = true;
                node.complete = true;
                GetChild(root.OrgCode, node.ChildNodes);
                node.hasChildren = true;
                nodes.Add(node);
            }
            else
            {
                GetChild(parentId, nodes);
            }
            return Json(nodes);
        }
        private void GetChild(string OrgCode, List<JsonTreeNode> parentNodes)
        {
            var glist = sysManageService.GetChildOrgsByParentCode(OrgCode);
            if (glist != null)
            {
                foreach (var item in glist)
                {
                    JsonTreeNode gnode = new JsonTreeNode();
                    gnode.id = item.OrgCode;
                    gnode.text = item.OrgName;
                    gnode.value = "1";
                    gnode.hasChildren = true;

                    gnode.classes = "group";
                    parentNodes.Add(gnode);
                }
            }
            var ulist = sysManageService.GetUserListByOrgCode(OrgCode);
            if (ulist != null)
            {
                foreach (var user in ulist)
                {
                    JsonTreeNode unode = new JsonTreeNode();
                    unode.id = user.UserUID;
                    unode.text = user.FullName;
                    unode.value = "2";
                    unode.showcheck = true;
                    unode.hasChildren = false;
                    unode.classes = "user";
                    parentNodes.Add(unode);
                }
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult QueryUser(FormCollection form)
        {
            string userCode = form["userCode"];
            List<UserInfo> list = sysManageService.QueryUserList(userCode);
            return Json(list);
        }
        #endregion

        #region 权限管理
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_Privilege_PagePrivilegeCode)]
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
                parentCode = null;
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
                if (parentId == null && nodes.Count > 0 && nodes[0].hasChildren) //如果是根
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
        public ActionResult EditPrivilege(string id, string parentCode, string parentName)
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
        public JsonResult SavePrivilegeInfo(string id, Privilege p)
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

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetRolePrivileges(int RoleID, FormCollection form)
        {
            List<JsonTreeNode> treelist = new List<JsonTreeNode>();

            string parentId = form["id"];


            List<Privilege> list = sysManageService.GetRoleAuthorizationPermissions(RoleID, base.UserId, parentId);
            foreach (Privilege p in list)
            {
                JsonTreeNode node = new JsonTreeNode();
                node.hasChildren = p.HasChild;
                node.id = p.PrivilegeCode;
                node.text = p.PrivilegeName;
                node.value = p.IsChecked ? "true" : "false";
                node.showcheck = true;
                node.checkstate = p.IsChecked ? (byte)1 : (byte)0;
                if (string.IsNullOrEmpty(parentId) && node.hasChildren && treelist.Count == 0) //如果是第一层就再获取一层
                {
                    List<Privilege> clist = sysManageService.GetRoleAuthorizationPermissions(RoleID, base.UserId, node.id);
                    foreach (Privilege cp in clist)
                    {
                        JsonTreeNode cnode = new JsonTreeNode();
                        cnode.hasChildren = cp.HasChild;
                        cnode.id = cp.PrivilegeCode;
                        cnode.text = cp.PrivilegeName;
                        cnode.value = cp.IsChecked ? "true" : "false";
                        cnode.showcheck = true;
                        cnode.checkstate = cp.IsChecked ? (byte)1 : (byte)0;
                        node.ChildNodes.Add(cnode);
                    }
                    node.complete = true;
                    node.isexpand = true;
                }

                treelist.Add(node);
            }
            return Json(treelist);

        }
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_Authorization_PagePrivilegeCode)]
        public ActionResult QueryAuthorization()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult QueryUserPrivilegeTree(FormCollection form)
        {
            List<JsonTreeNode> treelist = new List<JsonTreeNode>();
            string usercode = form["UserCode"];
            string parentId = form["id"] ?? "";


            List<Privilege> list = sysManageService.GetUserPrivilegesByParentID(usercode, parentId);
            foreach (Privilege pri in list)
            {

                JsonTreeNode node = new JsonTreeNode();
                node.hasChildren = pri.HasChild;
                node.id = pri.PrivilegeCode;
                node.text = pri.PrivilegeName;
                node.value = pri.PrivilegeCode;
                if (parentId == "" && node.hasChildren)
                {
                    List<Privilege> clist = sysManageService.GetUserPrivilegesByParentID(usercode, node.id);
                    foreach (Privilege cpri in clist)
                    {
                        JsonTreeNode cnode = new JsonTreeNode();
                        cnode.hasChildren = cpri.HasChild;
                        cnode.id = cpri.PrivilegeCode;
                        cnode.text = cpri.PrivilegeName;
                        cnode.value = cpri.PrivilegeCode;
                        node.ChildNodes.Add(cnode);
                    }
                    node.isexpand = true;
                    node.complete = true;
                }
                treelist.Add(node);
            }
            return Json(treelist);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult QueryPrivilegeRoles(FormCollection form)
        {
            string pcode = form["pCode"];// 权限标识
            string usercode = form["userCode"];// 权限标识

            List<RoleInfo> list = sysManageService.QueryUserPrivilegeRoles(usercode, pcode);
            List<string[]> rlist = new List<string[]>();
            foreach (RoleInfo role in list)
            {
                rlist.Add(new string[] { role.RoleID.ToString(), role.RoleCode, role.RoleName, role.IsSystem ? "1" : "0" });
            }
            return Json(rlist);
        }
        #endregion

        #region 数据字典管理
        [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_Dict_PagePrivilegeCode)]
        public ActionResult DictInfoList()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DictInfoList(FormCollection form)
        {
            string colkey = form["colkey"];
            string colsinfo = form["colsinfo"];
            string strparentId = form["ParentID"];
            int parentId = 0;
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
            List<DictInfo> list = sysManageService.QueryDictInfoList(parentId);
            var data = JsonFlexiGridData.ConvertFromList(list, colkey, colsinfo.Split(','));
            return Json(data);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DictTreeList(FormCollection form)
        {
            List<JsonTreeNode> nodes = new List<JsonTreeNode>();
            string strparentId = form["id"];// ?? "0";
            int parentId = 0;
            if (!string.IsNullOrEmpty(strparentId))
            {
                parentId = Convert.ToInt32(strparentId);

            }
            List<DictInfo> list = sysManageService.GetDictInfoTree(parentId);
            foreach (var item in list)
            {
                JsonTreeNode cnode = new JsonTreeNode();
                cnode.id = item.DictID.ToString();
                cnode.text = item.DictName;
                cnode.value = item.DictCode;
                cnode.hasChildren = item.HasChild;
                cnode.classes = item.IsSystem ? "system" : "normal";
                nodes.Add(cnode);
            }
            return Json(nodes);
        }
        public ActionResult EditDictInfo(int? id, int? ParentID, string ParentName)
        {
            DictInfo di;
            if (id.HasValue)
            {
                di = sysManageService.GetDictInfo(id.Value);
                if (di == null)
                {
                    throw new ArgumentException("参数错误，不存在对应的数据字典", "DictID");
                }
                else //处理
                {

                }
            }
            else
            {
                di = new DictInfo();
                if (ParentID.HasValue)
                {
                    di.ParentID = ParentID.Value;
                    di.ParentName = ParentName;
                }
                else
                {

                    di.ParentID = 0;
                    di.ParentName = "数据字典";
                }
            }
            return View(di);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveDictInfo(int? id, DictInfo di)
        {
            JsonReturnMessages msg = new JsonReturnMessages();
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    di.IsNew = false;
                    di.DictID = id.Value;
                }
                else
                {
                    di.IsNew = true;
                }
                di.IsSystem = false;

                sysManageService.SaveDictInfo(di);
                msg.IsSuccess = true;
                msg.Msg = "操作成功";
            }
            catch (BizException ex)
            {
                msg.IsSuccess = false;
                msg.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.Msg = "操作失败：" + ex.Message;
            }
            return Json(msg);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteDictInfo(int id)
        {
            JsonReturnMessages msg = new JsonReturnMessages();

            try
            {
                int ret = sysManageService.DeleteDictInfo(id);
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

        #endregion

        #region 操作日志
       [xEasyAppAuthorize(PagePrivilegeCode = Constants.SystemManage_LogManage_PagePrivilegeCode)]
        public ActionResult LogList()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult LogList(FormCollection form)
        {
            int pageIndex = Convert.ToInt32(form["page"]);
            int pageSize = Convert.ToInt32(form["rp"]);
            PageView view = new PageView();
            view.PageIndex = pageIndex - 1;
            view.PageSize = pageSize;
            string colkey = form["colkey"];
            string colsinfo = form["colsinfo"];
            string qtext = form["QText"];
            string optype = form["OperateCode"];
            LogType logtype = LogType.None;
            switch (form["LogType"])
            {
                case "0":
                    logtype = LogType.Debug;
                    break;
                case "1":
                    logtype = LogType.Trace;
                    break;
                case "2":
                    logtype = LogType.Error;
                    break;

            }
            ILogService service = ObjectFactory.GetInstance<ILogService>();
            PagedList<Log> plist = service.QueryOperLog(view, qtext, optype, logtype);
            JsonFlexiGridData fdata = JsonFlexiGridData.ConvertFromPagedList<Log>(plist, colkey, colsinfo.Split(','));
            return Json(fdata);
        }
        #endregion
    }
}
