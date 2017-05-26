using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace YuSpin.Fw.EntityFramework.StoredProcedures.Parameters
{
    public class StoredProcParamCollection : Collection<StoredProcParam>
    {
        public StoredProcParam this[string paramName]
        {
            get
            {
                return this.Single(x=>x.Name.Equals(paramName, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        public T GetValue<T>(string paramName)
        {
            var p = this.SingleOrDefault(x => x.Name.Equals(paramName, System.StringComparison.CurrentCultureIgnoreCase));

            if (p != null && (p.Value != null && !Convert.IsDBNull(p.Value)))
                return (T)p.Value;
            else
                return default(T);
        }
    }
}
