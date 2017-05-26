using IRS.Domain.Interfaces.QC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.EntityFramework.QC;

namespace YuSpin.Fw.EntityFramework
{
    public interface IPageableSortableQuery: IQuery
    {
        PageSortFilter Filter { get; set; }
    }
}
