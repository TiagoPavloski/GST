using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BI.GST.Application.ViewModels;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IGrupoCipaAppService : IDisposable
    {
        IEnumerable<GrupoCipaViewModel> ObterTodos();

        GrupoCipaViewModel ObterPorId(int id);

    }
}
