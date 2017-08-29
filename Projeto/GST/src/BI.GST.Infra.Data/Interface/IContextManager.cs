using BI.GST.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Interface
{
    public interface IContextManager
    {
        ProjetoContext GetContext();
    }
}
