using Padmate.ERP.Models;
using Padmate.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padmate.ERP.Web.Controllers
{
    public class BaseController:Controller
    {
        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
        /// <returns></returns>
        public M_User GetCurrentUser()
        {
            M_User user = null;
            if (Session != null)
            {
                user = (M_User)Session[Common.SessionLoginUser];
            }

            return user;
        }
    }
}