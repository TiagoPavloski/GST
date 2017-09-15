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
  public class FuncionarioService : IFuncionarioService
  {
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
      _funcionarioRepository = funcionarioRepository;
    }

    public void Adicionar(Funcionario funcionario)
    {
      _funcionarioRepository.Adicionar(funcionario);
    }

    public void Atualizar(Funcionario funcionario)
    {
      _funcionarioRepository.Atualizar(funcionario);
    }

    public void Dispose()
    {
      _funcionarioRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _funcionarioRepository.Excluir(id);
    }

    public IEnumerable<Funcionario> Find(Expression<Func<Funcionario, bool>> predicate)
    {
      return _funcionarioRepository.Find(predicate);
    }

    public IEnumerable<Funcionario> ObterGrid(int page, string pesquisa)
    {
      return _funcionarioRepository.ObterGrid(page, pesquisa);
    }

    public Funcionario ObterPorId(int id)
    {
      return _funcionarioRepository.ObterPorId(id);
    }

    public IEnumerable<Funcionario> ObterTodos()
    {
      return _funcionarioRepository.ObterTodos();
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _funcionarioRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
