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
    public class EmpresaUtilizadoraService : IEmpresaUtilizadoraService
    {
        private readonly IEmpresaUtilizadoraRepository _empresaUtilizadoraRepository;

        public EmpresaUtilizadoraService(IEmpresaUtilizadoraRepository empresaUtilizadoraRepository)
        {
            _empresaUtilizadoraRepository = empresaUtilizadoraRepository;
        }

        public void Adicionar(EmpresaUtilizadora empresaUtilizadora)
        {
            _empresaUtilizadoraRepository.Adicionar(empresaUtilizadora);
        }

        public void Atualizar(EmpresaUtilizadora empresaUtilizadora)
        {
            _empresaUtilizadoraRepository.Atualizar(empresaUtilizadora);
        }

        public void Dispose()
        {
            _empresaUtilizadoraRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _empresaUtilizadoraRepository.Excluir(id);
        }

        public IEnumerable<EmpresaUtilizadora> Find(Expression<Func<EmpresaUtilizadora, bool>> predicate)
        {
            return _empresaUtilizadoraRepository.Find(predicate);
        }

        public IEnumerable<EmpresaUtilizadora> ObterGrid(int page, string pesquisa)
        {
            return _empresaUtilizadoraRepository.ObterGrid(page, pesquisa);
        }

        public EmpresaUtilizadora ObterPorId(int id)
        {
            return _empresaUtilizadoraRepository.ObterPorId(id);
        }

        public IEnumerable<EmpresaUtilizadora> ObterTodos()
        {
            return _empresaUtilizadoraRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _empresaUtilizadoraRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
