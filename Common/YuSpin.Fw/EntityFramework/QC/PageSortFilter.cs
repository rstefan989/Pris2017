using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.EntityFramework.QC
{
    public class PageSortFilter
    {
        public string SearchString { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public int TotalRows { get; set; }
        public int PageCount { get { return (int)Math.Ceiling((double)TotalRows / PageSize); } }
    }
}
