using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Utilities.Log
{
    //USO DE INTERFACES
    public interface ILog<T>
    {
        void SaveLog(T action);
    }
}
