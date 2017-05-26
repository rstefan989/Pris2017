using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.EntityFramework.Pagination;

namespace YuSpin.Fw.Extensions
{
    public static class EfExtensions
    {
        /// <summary>
        /// Sorts the source data by IPageSearchCriteria
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="source">IQueryable</param>
        /// <param name="pagingCriteria">set of data needed for sorting</param>
        /// <param name="defaultSortColumn">default sort column </param>
        /// <param name="defaultSortDirection">asc or desc</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, 
                                                    IPageSearchCriteria pagingCriteria, 
                                                    string defaultSortColumn = "",
                                                string defaultSortDirection = "asc")
        {
            if (string.IsNullOrEmpty(pagingCriteria.SortColumn) && defaultSortColumn == "")
                throw new Exception("The sort criteria or default sort column is not set.");

            pagingCriteria.SortColumn = pagingCriteria.SortColumn ?? defaultSortColumn;
            pagingCriteria.SortDirection = pagingCriteria.SortDirection ?? defaultSortDirection;
            
            var result = source.OrderBy(pagingCriteria.SortColumn + " " + pagingCriteria.SortDirection);

            return result;
        }

        public static IPagination<T> AsPage<T>(this IEnumerable<T> source, IPageSearchCriteria pagingCriteria)
        {
                return new Pagination<T>(source.AsQueryable<T>(), pagingCriteria);
        }

        //public static IPagination<T> AsPage<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        //{
        //    return new Pagination<T>(source.AsQueryable<T>(), pageIndex, pageSize);
        //}

        public static IEnumerable<string> KeysFor(this DbContext context, Type entityType)
        {
            Contract.Requires(context != null);
            Contract.Requires(entityType != null);

            entityType = ObjectContext.GetObjectType(entityType);

            var metadataWorkspace =
                ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            var objectItemCollection =
                (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);

            var ospaceType = metadataWorkspace
                .GetItems<EntityType>(DataSpace.OSpace)
                .SingleOrDefault(t => objectItemCollection.GetClrType(t) == entityType);

            if (ospaceType == null)
            {
                throw new ArgumentException(
                    string.Format(
                        "The type '{0}' is not mapped as an entity type.",
                        entityType.Name),
                    "entityType");
            }

            return ospaceType.KeyMembers.Select(k => k.Name);
        }

        public static object[] KeyValuesFor(this DbContext context, object entity)
        {
            Contract.Requires(context != null);
            Contract.Requires(entity != null);

            var entry = context.Entry(entity);
            return context.KeysFor(entity.GetType())
                .Select(k => entry.Property(k).CurrentValue)
                .ToArray();
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
