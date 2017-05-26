using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YuSpin.Fw.EntityFramework.Pagination
{
    public class Pagination<T> : IPagination<T>
    {
        private readonly IQueryable<T> _query;

        private int _pageNumber, _pageSize = 15;
        private int _totalItems;
        private int _backward;

        public Pagination(IEnumerable<T> items,
                                int pageNumber,
                                int pageSize,
                                int totalItems, 
                                string sortColumn, 
                                string sortDirection)
        {
            this.Items = items;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.SortColumn = sortColumn;
            this.SortDirection = sortDirection;

            this._totalItems = totalItems;
        }

        public Pagination(IQueryable<T> query, IPageSearchCriteria pagingCriteria) 
        {
            this._query = query;
            this.PageNumber = pagingCriteria.PageNumber == 0 ? 1 : pagingCriteria.PageNumber;
            this.PageSize = pagingCriteria.PageSize;
            this.SortColumn = pagingCriteria.SortColumn;
            this.SortDirection = pagingCriteria.SortDirection;

            this.Items = this._ExecuteQuery();
        }

        private IEnumerable<T> Items
        {
            get;
            set;
        }

        private IEnumerable<T> _ExecuteQuery()
        {
            return this._query.Skip((this.PageNumber - 1) * this.PageSize).Take(this.PageSize).ToList<T>();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public int TotalItems
        {
            get
            {
                return this._query == null ? this._totalItems : this._query.Count();
            }
            set { this._totalItems = value; }
        }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(((double)this.TotalItems) / this.PageSize); }
            set { }
        }

        public int FirstItem
        {
            get { return (this.PageNumber * this.PageSize) + 1; }
            set { }
        }

        public int LastItem
        {
            get { return this.FirstItem + this.Items.Count() - 1; }
            set { }
        }

        public bool HasPrevious
        {
            get { return this.PageNumber > 1; }
            set { }
        }

        public bool HasNext
        {
            get { return this.PageNumber < this.TotalPages; }
            set { }
        }

        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set { this._pageSize = value; }
        }

        public int PageNumber
        {
            get
            {
                return this._pageNumber;
            }
            set { this._pageNumber = value; }
        }

        public string SortColumn
        {
            get; set;
        }

        public string SortDirection
        {
            get;
            set;
        }

        public int Backward
        {
            get { return this._backward; }
            set { this._backward = 1; }
        }

        public int Forward
        {
            get { return this.TotalPages - 1; }
        }
    }
}
