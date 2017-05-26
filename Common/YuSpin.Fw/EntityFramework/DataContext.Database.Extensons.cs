using IRS.Domain.Interfaces.QC;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using YuSpin.Fw.EntityFramework.Interfaces.QC;
using YuSpin.Fw.EntityFramework.StoredProcedures;
using YuSpin.Fw.EntityFramework.StoredProcedures.Parameters;

namespace YuSpin.Fw.EntityFramework
{
        public static class DataContextExtension
        {
            #region List<T> ExecuteQuery<T>
            /// <summary>
            /// Returns specified resultset of type T
            /// </summary>
            public static List<T> ExecuteQuery<T>(this Database db, IQuery query) where T : class
            {
                query.ResultTypes = new Type[] { typeof(T) };

                var result = ExecuteQuery(db, query) as ResultSets;
                var resultset = result.SingleOrDefault(x => x.GetType() == typeof(List<T>));

                return resultset as List<T>;
            }
            #endregion

            #region ResultSets ExecuteQuery
            /// <summary>
            /// Returns single or multiple resultset
            /// </summary>
            public static ResultSets ExecuteQuery(this Database db, IQuery query)
            {
                Func<DbCommand, ResultSets> action = (DbCommand cmd) =>
                {
                    var result = new ResultSets();
                    var dbReader = cmd.ExecuteReader();

                    var objectContext = ((IObjectContextAdapter)db.GetDataContext()).ObjectContext;
                    var translateMethod = objectContext.GetType().GetMethod("Translate", new Type[] { typeof(DbDataReader) });

                    if (query.ResultTypes != null && query.ResultTypes.Any())
                    {
                        foreach (var expectedResultType in query.ResultTypes)
                        {
                            var translateGenericMethod = translateMethod.MakeGenericMethod(expectedResultType);
                            var resultSet = translateGenericMethod.Invoke(objectContext, new object[] { dbReader });

                            var toListGenericMethod =
                                typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(expectedResultType);
                            var list = toListGenericMethod.Invoke(null, new object[] { resultSet });

                            ((ResultSets)result).Add(list);
                            dbReader.NextResult();
                        }
                    }

                    dbReader.Close();

                    return result;
                };

                return CallStoredProc<ResultSets>(db, query, action);
            }
            #endregion

            #region ExecuteNonQuery
            /// <summary>
            /// Executes non query comamnds
            /// </summary>
            public static int ExecuteNonQuery(this Database db, ICommand command)
            {
                Func<DbCommand, int> action = (DbCommand cmd) =>
                {
                    return cmd.ExecuteNonQuery();
                };

                return CallStoredProc<int>(db, command, action);
            }
            #endregion

            #region ExecuteScalar<T>
            /// <summary>
            /// returns command scalar value 
            /// </summary>
            public static T ExecuteScalar<T>(this Database db, StoredProcedure storedProc) 
            {
                Func<DbCommand, T> action = (DbCommand cmd) =>
                {
                    var o = cmd.ExecuteScalar();
                    return (T)o;
                };
              
                 return CallStoredProc<T>(db, storedProc, action);
            }
            #endregion

            public static DbContext GetDataContext(this Database db)
            {
                var fieldInfo = db.GetType().GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance);
                var internalContext = fieldInfo.GetValue(db);
                var dataContext = internalContext.GetType().GetProperty("Owner").GetValue(internalContext);

                return (DbContext)dataContext;
            }

            #region LOCAL METHODES
        
            static T CallStoredProc<T>(this Database db, IStoredProcedure storedProc, Func<DbCommand, T> executeAction) 
            {
                bool shouldCloseConnection = false;
                object result = null;

             //   object dataContext = null;
                var cmd = db.Connection.CreateCommand();
                cmd.CommandTimeout = storedProc.Timeout;

                cmd.Parameters.AddRange(GetParameters(storedProc.Parameters).ToArray());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc.Name;

                try
                {
                    if (db.Connection.State != ConnectionState.Open)
                    {
                        db.Connection.Open();
                        shouldCloseConnection = true;
                    }
                    result = executeAction.Invoke(cmd);
                }
                finally
                {
                    if (shouldCloseConnection)
                        db.Connection.Close();
                    ProcessOutputParameters(storedProc, cmd);
                }

                return (T)result;
            }

            private static void ProcessOutputParameters(IStoredProcedure storedProc, DbCommand storedprocCommand)
            {
                if (storedProc.Parameters != null)
                {
                    foreach (var p in storedProc.Parameters.Where(x => x.Direction == ParameterDirection.Output))
                    {
                        p.Value = storedprocCommand.Parameters[p.Name].Value;
                    }
                }
            }

            //private static List<SqlParameter> GetParameters(IEnumerable<StoredProcParam> collection)
            //{
            //    if (collection == null) return new List<SqlParameter>();

            //    var pList = collection.Select(p => new SqlParameter { ParameterName = string.Format("@{0}", p.Name), Direction = p.Direction, DbType = p.Type, Value = p.Value ?? null }).ToList();
            //    return pList;
            //}

        private static List<MySqlParameter> GetParameters(IEnumerable<StoredProcParam> collection)
        {
            if (collection == null) return new List<MySqlParameter>();

            //MySqlParameter
            var pList = collection.Select(p => new MySqlParameter { ParameterName = p.Name, Direction = p.Direction, DbType = p.Type, Value = p.Value ?? null }).ToList();
            return pList;
        }

        #endregion
    }
}
