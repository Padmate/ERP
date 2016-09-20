using Padmate.ERP.Entities;
using Padmate.ERP.Models;
using Padmate.ERP.Services;
using Padmate.ERP.Utility;
using Padmate.ERP.Web.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padmate.ERP.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Default()
        {

            return View(); 
        }

        [Authorization]
        public ActionResult Index()
        {
            

            return View();
        }

        [Authorization]
        public ActionResult IndexHome()
        {
            return View();
        }


        public ActionResult LoadTreeData()
        {
            //当前登录用户
            var user = GetCurrentUser();
            //根据当前用户的角色查找菜单
            string role = "supply";
            var extTreeData = ExtTreeConfig.Init.ExtTreeDatas(role);

            extTreeData.children.First().text += "<small class='label pull-right bg-green'>new</small>";
            return Json(extTreeData);

            #region 构造菜单
            //#region leafNode
            //M_ExtTreeNode leafNode1 = new M_ExtTreeNode();
            //leafNode1.id = "1";
            //leafNode1.iframesrc = "/Home/Contact";
            //leafNode1.text = "Tab页面1";
            //leafNode1.leaf = true;

            //M_ExtTreeNode leafNode2 = new M_ExtTreeNode();
            //leafNode2.id = "2";
            //leafNode2.iframesrc = "/Home/Contact";
            //leafNode2.text = "Tab页面2";
            //leafNode2.leaf = true;

            //M_ExtTreeNode leafNode3 = new M_ExtTreeNode();
            //leafNode3.id = "3";
            //leafNode3.iframesrc = "/Home/Contact";
            //leafNode3.text = "Tab页面3";
            //leafNode3.leaf = true;

            //M_ExtTreeNode leafNode4 = new M_ExtTreeNode();
            //leafNode4.id = "4";
            //leafNode4.iframesrc = "/Home/Contact";
            //leafNode4.text = "Tab页面4";
            //leafNode4.leaf = true;

            //M_ExtTreeNode leafNode5 = new M_ExtTreeNode();
            //leafNode5.id = "5";
            //leafNode5.iframesrc = "/Home/Contact";
            //leafNode5.text = "Tab页面5";
            //leafNode5.leaf = true;

            //#endregion
            //#region 二级菜单
            //M_ExtTreeNode secondNod1 = new M_ExtTreeNode();
            //secondNod1.text = "菜单一";
            //secondNod1.expanded = true;
            //secondNod1.leaf = false;
            //secondNod1.children = new List<M_ExtTreeNode>() { 
            //    leafNode1,leafNode2,leafNode3
            //};

            //M_ExtTreeNode secondNod2 = new M_ExtTreeNode();
            //secondNod2.text = "菜单二";
            //secondNod2.expanded = false;
            //secondNod2.leaf = false;
            //secondNod2.children = new List<M_ExtTreeNode>() { 
            //    leafNode4
            //};

            //M_ExtTreeNode secondNod3 = new M_ExtTreeNode();
            //secondNod3.text = "菜单三";
            //secondNod3.expanded = false;
            //secondNod3.leaf = false;
            //secondNod3.children = new List<M_ExtTreeNode>() { 
            //    leafNode5
            //};
            //#endregion
            //M_ExtTreeNode firstNode = new M_ExtTreeNode();
            //firstNode.leaf = false;
            //firstNode.expanded = false;
            //firstNode.leaf = false;
            //firstNode.children = new List<M_ExtTreeNode>() { 
            //    secondNod1,secondNod2,secondNod3
            //};

            #endregion
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetWebLogPageData(BaseModel model)
        {
            // 获取客户端对象
            //HttpRequestBase httpRequest = Request;
            //StreamReader streamReader = new StreamReader(httpRequest.InputStream);
            //String strReqStream = streamReader.ReadToEnd();
            //BaseModel model = JsonHandler.UnJson<BaseModel>(strReqStream);

            List<test> data = new List<test>() { 
                new test(){ID="1",TypeID="1111111111",LogConetnt="中文"},
                new test(){ID="2",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="3",TypeID="333333333",LogConetnt="中文"},
                new test(){ID="4",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="5",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="6",TypeID="333333333",LogConetnt="中文"},
                new test(){ID="7",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="8",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="9",TypeID="333333333",LogConetnt="中文"},
                new test(){ID="10",TypeID="1111111111",LogConetnt="中文"},
                new test(){ID="11",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="12",TypeID="333333333",LogConetnt="sdfsdfsdf3"},
                new test(){ID="13",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="14",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="15",TypeID="333333333",LogConetnt="sdfsdfsdf3"},
                new test(){ID="16",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="17",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="18",TypeID="333333333",LogConetnt="sdfsdfsdf3"},
                new test(){ID="19",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="20",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="21",TypeID="333333333",LogConetnt="sdfsdfsdf3"},
                new test(){ID="22",TypeID="1111111111",LogConetnt="sdf1"},
                new test(){ID="23",TypeID="222222222",LogConetnt="sdf2"},
                new test(){ID="24",TypeID="333333333",LogConetnt="sdfsdfsdf3"}
            };

            var result = data
                .Skip((model.page-1)*model.limit)
                .Take(model.limit)
                .ToList();

            PageData<test> pageData = new PageData<test>(data.Count, result);
            return Json(pageData);
        }
    }
}