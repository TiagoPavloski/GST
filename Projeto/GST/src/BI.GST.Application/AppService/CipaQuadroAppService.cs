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
    public class CipaQuadroAppService : BaseAppService, ICipaQuadroAppService
    {
        private readonly ICipaQuadroService _cipaQuadroService;

        public CipaQuadroAppService(ICipaQuadroService cipaQuadroService)
        {
            _cipaQuadroService = cipaQuadroService;
        }

        public void Dispose()
        {
            _cipaQuadroService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CipaQuadroViewModel obterCipaPorGrupo(int numeroFuncionarios, int grauDeRisco)
        {
            return Mapper.Map<CipaQuadro, CipaQuadroViewModel>(_cipaQuadroService.obterCipaPorGrupo(numeroFuncionarios, grauDeRisco));
        }

        public CipaQuadroViewModel ObterPorId(int id)
        {
            return Mapper.Map<CipaQuadro, CipaQuadroViewModel>(_cipaQuadroService.ObterPorId(id));
        }

        public IEnumerable<CipaQuadroViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CipaQuadro>, IEnumerable<CipaQuadroViewModel>>(_cipaQuadroService.ObterTodos());
        }
    }
}
