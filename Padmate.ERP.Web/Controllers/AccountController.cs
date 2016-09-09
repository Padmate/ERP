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
            //校验系统中是否存在该用户

            //校验密码
            //对客户端密码进行再次Hash
            var loginHashPassword = PasswordHash.CreatePasswordAndSaltHash(model.Password);

            //判断登录密码是否正确
            if (!PasswordHash.ValidatePassword(model.Password, "MTAwMDpKOHBCUjFUUGdQdWR6c2lzYnhyQmNUbHFyKzVORWUxVjpKanZYVW9YcDQyUVJyZUkwNlNuaEExdG82c0wyRE1reg=="))
            {
                message.Success = false;
                message.Content = "用户名或密码不正确";
                return Json(message);
            }

            //如果用户登录成功，则将用户信息写入session
            M_User user = new M_User();
            user.UserName = model.UserName;
            //设置过期时间为4H
            Session[Common.SessionLoginUser] = user;
            Session.Timeout = 240;


            return Json(message);
        }

        [HttpPost]
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