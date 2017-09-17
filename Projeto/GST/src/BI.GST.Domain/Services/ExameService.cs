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
  public class ExameService : IExameService
  {
    private readonly IExameRepository _exameRepository;

    public ExameService(IExameRepository exameRepository)
    {
      _exameRepository = exameRepository;
    }

    public void Adicionar(Exame exame)
    {
      _exameRepository.Adicionar(exame);
    }

    public void Atualizar(Exame exame)
    {
      _exameRepository.Atualizar(exame);
    }

    public void Dispose()
    {
      _exameRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _exameRepository.Excluir(id);
    }

    public IEnumerable<Exame> Find(Expression<Func<Exame, bool>> predicate)
    {
      return _exameRepository.Find(predicate);
    }

    public IEnumerable<Exame> ObterGrid(int page, string pesquisa)
    {
      return _exameRepository.ObterGrid(page, pesquisa);
    }

    public Exame ObterPorId(int id)
    {
      return _exameRepository.ObterPorId(id);
    }

    public IEnumerable<Exame> ObterTodos()
    {
      return _exameRepository.ObterTodos();
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _exameRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
