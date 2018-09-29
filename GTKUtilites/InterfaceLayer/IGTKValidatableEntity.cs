using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.InterfaceLayer
{
    public interface IGTKEntityValidator<T>
    {
        bool IsValid(T Entity);
    }
}
