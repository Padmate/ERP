using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.Models
{
    public class M_Login
    {
    }

    public class LoginViewModel:BaseModel
    {
        [Required(ErrorMessage="请输入用户名")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage="请输入密码")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

    }
}
