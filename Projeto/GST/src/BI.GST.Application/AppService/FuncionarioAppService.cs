using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
  public class FuncionarioAppService : BaseAppService, IFuncionarioAppService
  {
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioAppService(IFuncionarioService funcionarioService)
    {
      _funcionarioService = funcionarioService;
    }
    public bool Adicionar(FuncionarioViewModel funcionarioViewModel)
    {
      var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

      var duplicado = _funcionarioService.Find(e => e.Nome == funcionario.Nome).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _funcionarioService.Adicionar(funcionario);
        Commit();
        return true;
      }
    }

    public bool Atualizar(FuncionarioViewModel funcionarioViewModel)
    {
      var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

      var duplicado = _funcionarioService.Find(e => e.Nome == funcionario.Nome && e.FuncionarioId != funcionario.FuncionarioId).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _funcionarioService.Atualizar(funcionario);
        Commit();
        return true;
      }

    }

    public void Dispose()
    {
      _funcionarioService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _funcionarioService.Find(e => e.FuncionarioId == id).Any();
      //EXCLUIR Cursos/Vacinas/Exames Vinculados ao Funcionario

      if (existente)
      {
        BeginTransaction();
        var funcionario = _funcionarioService.ObterPorId(id);
        funcionario.Delete = true;
        _funcionarioService.Atualizar(funcionario);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<FuncionarioViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterGrid(page, pesquisa));
    }

    public FuncionarioViewModel ObterPorId(int id)
    {
      return Mapper.Map<Funcionario, FuncionarioViewModel>(_funcionarioService.ObterPorId(id));
    }

    public IEnumerable<FuncionarioViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _funcionarioService.ObterTotalRegistros(pesquisa);
    }
  }
}
