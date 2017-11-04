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
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public void Adicionar(Colaborador colaborador)
        {
            _colaboradorRepository.Adicionar(colaborador);
        }

        public void Atualizar(Colaborador colaborador)
        {
            _colaboradorRepository.Atualizar(colaborador);
        }

        public void Dispose()
        {
            _colaboradorRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _colaboradorRepository.Excluir(id);
        }

        public IEnumerable<Colaborador> Find(Expression<Func<Colaborador, bool>> predicate)
        {
            return _colaboradorRepository.Find(predicate);
        }

        public IEnumerable<Colaborador> ObterGrid(int page, string pesquisa)
        {
            return _colaboradorRepository.ObterGrid(page, pesquisa);
        }

        public Colaborador ObterPorId(int id)
        {
            return _colaboradorRepository.ObterPorId(id);
        }

        public IEnumerable<Colaborador> ObterTodos()
        {
            return _colaboradorRepository.ObterTodos();
        }

        public IEnumerable<Colaborador> ObterTodosPorEmpresa(int EmpresaId)
        {
            return _colaboradorRepository.ObterTodosPorEmpresa(EmpresaId);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _colaboradorRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
