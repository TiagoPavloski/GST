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
    public class SesmtQuadroService : ISesmtQuadroService
    {
        private readonly ISesmtQuadroRepository _sesmtQuadroRepository;

        public SesmtQuadroService(ISesmtQuadroRepository sesmtQuadroRepository)
        {
            _sesmtQuadroRepository = sesmtQuadroRepository;
        }

        public void Dispose()
        {
            _sesmtQuadroRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SesmtQuadro> Find(Expression<Func<SesmtQuadro, bool>> predicate)
        {
            return _sesmtQuadroRepository.Find(predicate);
        }

        public SesmtQuadro ObterPorId(int id)
        {
            return _sesmtQuadroRepository.ObterPorId(id);
        }

        public IEnumerable<SesmtQuadro> ObterTodos()
        {
            return _sesmtQuadroRepository.ObterTodos();
        }
    }
}
