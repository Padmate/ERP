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
    public class HomeController : Controller
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