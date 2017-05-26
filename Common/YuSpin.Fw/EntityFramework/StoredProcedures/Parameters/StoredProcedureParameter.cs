using System;
using System.Data;

namespace YuSpin.Fw.EntityFramework.StoredProcedures.Parameters
{
    public class StoredProcParam
    {
        public StoredProcParam(string paramName) :this(paramName, DbType.String, ParameterDirection.Input, null) {}
        public StoredProcParam(string paramName, DbType type) : this(paramName, type, ParameterDirection.Input, null) { }
        public StoredProcParam(string paramName, DbType type, ParameterDirection paramDirection) : this(paramName, type, paramDirection, null) { }
        public StoredProcParam(string paramName, object value) : this(paramName, DbType.String, ParameterDirection.Input, value) 
        {
            if (value != null)
            {
                Type valueType = value.GetType();
                if (valueType == typeof(DateTime) || valueType == typeof(DateTime?))
                    this.Type = DbType.DateTime;

                else if (valueType == typeof(decimal) || valueType == typeof(decimal?))
                    this.Type = DbType.Decimal;

                else if (valueType == typeof(double) || valueType == typeof(double?))
                    this.Type = DbType.Double;

                else if (valueType == typeof(Single) || valueType == typeof(Single?))  
                    this.Type = DbType.Single;

                else if (valueType == typeof(Int16) || valueType == typeof(Int16?))
                    this.Type = DbType.Int16;

                else if (valueType == typeof(Int32) || valueType == typeof(Int32?))
                    this.Type = DbType.Int32;

                else if (valueType == typeof(Int64) || valueType == typeof(Int64?))
                    this.Type = DbType.Int64;
            }
        }
        public StoredProcParam(string paramName, DbType type, object value) : this(paramName, type, ParameterDirection.Input, value) { }
        public StoredProcParam(string paramName, DbType paramType, ParameterDirection paramDirection, object value)
        {
            Name = paramName;
            Type = paramType;
            Direction = paramDirection;
            Value = value ?? DBNull.Value;
        }

        public string Name { get; set; }
        public ParameterDirection Direction { get; set;}
        public DbType Type { get; set; }
        public object Value { get; set; }
    }
}
