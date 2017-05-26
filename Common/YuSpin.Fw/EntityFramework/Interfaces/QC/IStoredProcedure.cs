using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.EntityFramework.StoredProcedures;
using YuSpin.Fw.EntityFramework.StoredProcedures.Parameters;

namespace YuSpin.Fw.EntityFramework.Interfaces.QC
{
    public interface IStoredProcedure
    {
        Type[] ResultTypes { get; set; }
        StoredProcParamCollection Parameters { get; set; }
        ICollection<ResultSets> ResultSets { get; set; }
        /// <summary>
        /// Represents timeout interval in seconds
        /// </summary>
        int Timeout { get; set; }
        string Name { get; set; }
    }
}
