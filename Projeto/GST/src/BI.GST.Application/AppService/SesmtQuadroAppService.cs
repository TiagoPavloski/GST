using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Application.AppService
{
    public class SesmtQuadroAppService : BaseAppService, ISesmtQuadroAppService
    {
        private readonly ISesmtQuadroService _sesmtQuadroService;

        public SesmtQuadroAppService(ISesmtQuadroService sesmtQuadroService)
        {
            _sesmtQuadroService = sesmtQuadroService;
        }

        public void Dispose()
        {
            _sesmtQuadroService.Dispose();
            GC.SuppressFinalize(this);
        }

        public SesmtQuadroViewModel ObterPorId(int id)
        {
            return Mapper.Map<SesmtQuadro, SesmtQuadroViewModel>(_sesmtQuadroService.ObterPorId(id));
        }

        public SesmtQuadroViewModel ObterSesmtPorGrauDeRisco(int numeroFuncionarios, int grupoCipaID)
        {
            return Mapper.Map<SesmtQuadro, SesmtQuadroViewModel>(_sesmtQuadroService.ObterSesmtPorGrauDeRisco(numeroFuncionarios, grupoCipaID));
        }

        public IEnumerable<SesmtQuadroViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<SesmtQuadro>, IEnumerable<SesmtQuadroViewModel>>(_sesmtQuadroService.ObterTodos());
        }
    }
}
