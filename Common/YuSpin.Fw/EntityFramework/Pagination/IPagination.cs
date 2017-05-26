using System.Collections.Generic;

namespace YuSpin.Fw.EntityFramework.Pagination
{
    public interface IPagination
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; }
        int FirstItem { get; }
        int LastItem { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
        string SortColumn { get; set; }
        string SortDirection { get; set; }
        int Backward { get; set; }
        int Forward { get; }
    }

    public interface IPagination<out T> : IPagination, IEnumerable<T>
    { }

    public interface IPageSearchCriteria
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string SortColumn { get; set; }
        string SortDirection { get; set; }
    }
}
