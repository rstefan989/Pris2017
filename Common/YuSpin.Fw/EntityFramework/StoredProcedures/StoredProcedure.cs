using System;
using System.Collections.Generic;
using YuSpin.Fw.EntityFramework.Interfaces.QC;
using YuSpin.Fw.EntityFramework.StoredProcedures;
using YuSpin.Fw.EntityFramework.StoredProcedures.Parameters;

namespace YuSpin.Fw.EntityFramework.StoredProcedures
{
    public class StoredProcedure: IStoredProcedure
    {
        public StoredProcedure()
        {
            Parameters = new StoredProcedures.Parameters.StoredProcParamCollection();
        }
        public Type[] ResultTypes { get; set; }
        public StoredProcParamCollection Parameters { get; set; }
        public ICollection<ResultSets> ResultSets { get; set; }
        public string Name { get; set; }

        public int Timeout { get; set; } = 30;
    }
}
