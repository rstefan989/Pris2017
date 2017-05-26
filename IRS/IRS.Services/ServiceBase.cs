using IRS.Domain.Interfaces.Configuration;
using IRS.Domain.Interfaces.QC;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;
using System.Collections.Generic;
using YuSpin.Fw.EntityFramework;
using YuSpin.Fw.EntityFramework.QC;
using YuSpin.Fw.EntityFramework.StoredProcedures;

namespace IRS.Services
{
    public class ServiceBase: IServiceBase
    {
        protected readonly IIoCResolver _iOCResolver;

        public IUnitOfWork UnitOfWork { get; private set; }
        public IAuthUser AuthUser { get; set; }

        public ServiceBase(IIoCResolver ioCResolver)
        {
            _iOCResolver = ioCResolver;

            UnitOfWork = _iOCResolver.Resolve<IUnitOfWork>();
            AuthUser = _iOCResolver.Resolve<IAuthUser>();
        }

        protected List<T> ExecuteQuery<T>(IQuery query) where T : class
        {
            return UnitOfWork.DataContext.ExecuteQuery<T>(query);
        }

        protected PageableSortableList<T> ExecutePageableSortableQuery<T>(IPageableSortableQuery query) where T : class
        {
            var queryResult = UnitOfWork.DataContext.ExecuteQuery<T>(query);

            var pagableSortableResult = new PageableSortableList<T>(queryResult);
            
            pagableSortableResult.PageSortParams = query.Filter;
            pagableSortableResult.PageSortParams.TotalRows = query.Parameters.GetValue<int>("TotalRows");

            return pagableSortableResult;
        }

        protected ResultSets ExecuteQuery(IQuery query)
        {
            return UnitOfWork.DataContext.ExecuteQuery(query);
        }
        protected void ExecuteCommand(ICommand command)
        {
            UnitOfWork.DataContext.ExecuteCommand(command);
        }
    }
}
