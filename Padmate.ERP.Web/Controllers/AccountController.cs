using Padmate.ERP.Models;
using Padmate.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Padmate.ERP.Web.Controllers
{
    public class AccountController:BaseController
    {
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Message message = new Message();
            message = model.validate();
            if (!message.Success)
            {
                return Json(message);
            }
            //校验用户名和密码

            //如果用户登录成功，则将用户信息写入session
            M_User user = new M_User();
            user.UserName = model.UserName;
            //设置过期时间为4H
            Session[Common.SessionLoginUser] = user;
            Session.Timeout = 240;


            return Json(message);
        }

        public ActionResult SignOut()
        {
            ClearUserSessionInfo();
            return RedirectToAction("Default","Home");
        }

        private void ClearUserSessionInfo()
        {
            if (Session != null)
            {
                try
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                }
                catch { }
            }
        }
    }
}