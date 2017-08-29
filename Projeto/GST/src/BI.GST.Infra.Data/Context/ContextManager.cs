using BI.GST.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BI.GST.Infra.Data.Context
{
    public class ContextManager : IContextManager //gerencia o estado do contexto
    {
        private const string ContextKey = "ContextManager.Context";

        public ProjetoContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new ProjetoContext();
            }
            return (ProjetoContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
