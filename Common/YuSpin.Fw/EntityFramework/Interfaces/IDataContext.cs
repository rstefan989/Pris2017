using IRS.Domain.Interfaces.QC;
using System.Collections.Generic;
using YuSpin.Fw.EntityFramework.StoredProcedures;

namespace YuSpin.Fw.EntityFramework
{
    public interface IDataContext
    {
        T ExecuteScalar<T>(StoredProcedure storedProc) where T : class;
        List<T> ExecuteQuery<T>(IQuery query) where T : class;
        ResultSets ExecuteQuery(IQuery query);
        void ExecuteCommand(ICommand command);


        string ID { get; set; }
    }
}