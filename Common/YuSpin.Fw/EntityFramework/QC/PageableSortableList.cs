using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.EntityFramework.QC
{
    public class PageableSortableList<T> : List<T>
    {
        public PageSortFilter PageSortParams { get; set; }
        public PageableSortableList(IEnumerable<T> source)
        {
            PageSortParams = new PageSortFilter();
            this.AddRange(source);
        }
    }
}
