using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Services
{
  public class TipoVacinaService : ITipoVacinaService
  {
    private readonly ITipoVacinaRepository _tipoVacinaRepository;

    public TipoVacinaService(ITipoVacinaRepository tipoVacinaRepository)
    {
      _tipoVacinaRepository = tipoVacinaRepository;
    }

    public void Adicionar(TipoVacina tipoVacina)
    {
      _tipoVacinaRepository.Adicionar(tipoVacina);
    }

    public void Atualizar(TipoVacina tipoVacina)
    {
      _tipoVacinaRepository.Atualizar(tipoVacina);
    }

    public void Dispose()
    {
      _tipoVacinaRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _tipoVacinaRepository.Excluir(id);
    }

    public IEnumerable<TipoVacina> Find(Expression<Func<TipoVacina, bool>> predicate)
    {
      return _tipoVacinaRepository.Find(predicate);
    }

    public IEnumerable<TipoVacina> ObterGrid(int page, string pesquisa)
    {
      return _tipoVacinaRepository.ObterGrid(page, pesquisa);
    }

    public TipoVacina ObterPorId(int id)
    {
      return _tipoVacinaRepository.ObterPorId(id);
    }

    public IEnumerable<TipoVacina> ObterTodos()
    {
      return _tipoVacinaRepository.ObterTodos();
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoVacinaRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
