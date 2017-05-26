using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Utilities
{
    public interface IAutoMapperTool
    {
        void Map<T1, T2>(T1 source, T2 destination);
    }
}
