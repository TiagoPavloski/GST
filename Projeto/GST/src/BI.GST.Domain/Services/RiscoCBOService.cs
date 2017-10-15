using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Services
{
  public class RiscoCBOService : IRiscoCBOService
  {
    private readonly IRiscoCBORepository _riscoCBORepository;

    public RiscoCBOService(IRiscoCBORepository riscoCBORepository)
    {
      _riscoCBORepository = riscoCBORepository;
    }

    public void Adicionar(RiscoCBO curso)
    {
      _riscoCBORepository.Adicionar(curso);
    }

    public void Atualizar(RiscoCBO curso)
    {
      _riscoCBORepository.Atualizar(curso);
    }

    public void Dispose()
    {
      _riscoCBORepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _riscoCBORepository.Excluir(id);
    }

    public IEnumerable<RiscoCBO> Find(Expression<Func<RiscoCBO, bool>> predicate)
    {
      return _riscoCBORepository.Find(predicate);
    }

    public IEnumerable<RiscoCBO> ObterGrid(int page)
    {
      return _riscoCBORepository.ObterGrid(page);
    }

    public RiscoCBO ObterPorId(int id)
    {
      return _riscoCBORepository.ObterPorId(id);
    }

    public IEnumerable<RiscoCBO> ObterTodos()
    {
      return _riscoCBORepository.ObterTodos();
    }

    public int ObterTotalRegistros()
    {
      return _riscoCBORepository.ObterTotalRegistros();
    }
  }
}
