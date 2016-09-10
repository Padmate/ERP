using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.Models
{
    public class PageData<T> where T : new()
    {
        public PageData(int totalCount,IList<T> rowsData)
        {
            this.total = totalCount;
            this.rows = rowsData;
        }

        public int total { get; set; }

        public IList<T> rows { get; set; }
    }
}
