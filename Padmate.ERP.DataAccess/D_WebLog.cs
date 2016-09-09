using Padmate.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.DataAccess
{
    public class D_WebLog
    {
        ERPDBContext _dbContext = new ERPDBContext();

        public List<WebLog> GetAll()
        {

            var webLogs = _dbContext.WebLogs
                .ToList();

            return webLogs;
        }
    }
}
