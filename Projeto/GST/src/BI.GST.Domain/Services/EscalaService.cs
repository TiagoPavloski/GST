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
  public class EscalaService : IEscalaService
  {
    private readonly IEscalaRepository _escalaRepository;

    public EscalaService(IEscalaRepository escalaRepository)
    {
      _escalaRepository = escalaRepository;
    }


    public void Dispose()
    {
      _escalaRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public IEnumerable<Escala> ObterTodos()
    {
      return _escalaRepository.ObterTodos();
    }

    public Escala ObterPorId(int id)
    {
      return _escalaRepository.ObterPorId(id);
    }

    public IEnumerable<Escala> Find(Expression<Func<Escala, bool>> predicate)
    {
      return _escalaRepository.Find(predicate);
    }

    public void Adicionar(Escala escala)
    {
      _escalaRepository.Adicionar(escala);
    }

    public void Atualizar(Escala escala)
    {
      _escalaRepository.Atualizar(escala);
    }

    public void Excluir(int id)
    {
      _escalaRepository.Excluir(id);
    }

    public IEnumerable<Escala> ObterGrid(int page, string pesquisa)
    {
      return _escalaRepository.ObterGrid(page, pesquisa);
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _escalaRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
