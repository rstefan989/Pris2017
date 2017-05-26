using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Utilities
{
    public interface IIoCResolver
    {
        object Resolve(Type type);
        T Resolve<T>();
    }
}
