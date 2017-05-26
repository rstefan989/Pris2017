using IRS.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Web.Code.Utilities
{
    public class AutoMapperTool : IAutoMapperTool
    {
        public void Map<T1,T2>(T1 source, T2 destination)
        {
            AutoMapper.Mapper.Map(source, destination);
        }
    }
}