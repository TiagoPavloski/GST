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

namespace BI.GST.Application.AppService
{
    public class GrupoCipaAppService : BaseAppService, IGrupoCipaAppService
    {
        private readonly IGrupoCipaService _grupoCipaService;

        public GrupoCipaAppService(IGrupoCipaService grupoCipaService)
        {
            _grupoCipaService = grupoCipaService;
        }

        public void Dispose()
        {
            _grupoCipaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public GrupoCipaViewModel ObterPorId(int id)
        {
            return Mapper.Map <GrupoCipa, GrupoCipaViewModel>(_grupoCipaService.ObterPorId(id));
        }

        public IEnumerable<GrupoCipaViewModel> ObterTodos()
        {
            return Mapper.Map < IEnumerable<GrupoCipa>, IEnumerable < GrupoCipaViewModel >>(_grupoCipaService.ObterTodos());
        }
    }
}
