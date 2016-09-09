using Padmate.ERP.DataAccess;
using Padmate.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.Services
{
    public class B_WebLog
    {
        public List<WebLog> GetAll()
        {
            D_WebLog dWebLog = new D_WebLog();
            var result = dWebLog.GetAll();

            return result;
        }
    }
}
