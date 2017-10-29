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
    public class TipoSetorService : ITipoSetorService
    {
        private readonly ITipoSetorRepository _tipoSetorRepository;

        public TipoSetorService(ITipoSetorRepository tipoSetorRepository)
        {
            _tipoSetorRepository = tipoSetorRepository;
        }

        public void Adicionar(TipoSetor tipoSetor)
        {
            _tipoSetorRepository.Adicionar(tipoSetor);
        }

        public void Atualizar(TipoSetor tipoSetor)
        {
            _tipoSetorRepository.Atualizar(tipoSetor);
        }

        public void Dispose()
        {
            _tipoSetorRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _tipoSetorRepository.Excluir(id);
        }

        public IEnumerable<TipoSetor> Find(Expression<Func<TipoSetor, bool>> predicate)
        {
            return _tipoSetorRepository.Find(predicate);
        }

        public IEnumerable<TipoSetor> ObterGrid(int page, string pesquisa)
        {
            return _tipoSetorRepository.ObterGrid(page, pesquisa);
        }

        public TipoSetor ObterPorId(int id)
        {
            return _tipoSetorRepository.ObterPorId(id);
        }

        public IEnumerable<TipoSetor> ObterTodos()
        {
            return _tipoSetorRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _tipoSetorRepository.ObterTotalRegistros(pesquisa);
        }
    }
    }
