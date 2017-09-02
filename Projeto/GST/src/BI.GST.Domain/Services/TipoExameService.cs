using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Domain.Interface.IRepository;

namespace BI.GST.Domain.Services
{
  public class TipoExameService : ITipoExameService
  {
    private readonly ITipoExameRepository _tipoExameRepository;

    public TipoExameService(ITipoExameRepository tipoExameRepository)
    {
      _tipoExameRepository = tipoExameRepository;
    }
    public void Adicionar(TipoExame exame)
    {
      _tipoExameRepository.Adicionar(exame);
    }

    public void Atualizar(TipoExame exame)
    {
      _tipoExameRepository.Atualizar(exame);
    }

    public void Dispose()
    {
      _tipoExameRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _tipoExameRepository.Excluir(id);
    }

    public IEnumerable<TipoExame> Find(Expression<Func<TipoExame, bool>> predicate)
    {
      return _tipoExameRepository.Find(predicate);
    }

    public IEnumerable<TipoExame> ObterGrid(int page, string pesquisa)
    {
      return _tipoExameRepository.ObterGrid(page, pesquisa);
    }

    public TipoExame ObterPorId(int id)
    {
      return _tipoExameRepository.ObterPorId(id);
    }

    public IEnumerable<TipoExame> ObterTodos()
    {
      return _tipoExameRepository.ObterTodos();
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoExameRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
