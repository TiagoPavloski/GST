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
    public class GrupoCipaService : IGrupoCipaService
    {
        private readonly IGrupoCipaRepository _grupoCipaRepository;

        public GrupoCipaService(IGrupoCipaRepository grupoCipaRepository)
        {
            _grupoCipaRepository = grupoCipaRepository;
        }

        public void Dispose()
        {
            _grupoCipaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<GrupoCipa> Find(Expression<Func<GrupoCipa, bool>> predicate)
        {
            return _grupoCipaRepository.Find(predicate);
        }

        public GrupoCipa ObterPorId(int id)
        {
            return _grupoCipaRepository.ObterPorId(id);
        }

        public IEnumerable<GrupoCipa> ObterTodos()
        {
            return _grupoCipaRepository.ObterTodos();
        }
    }
}
