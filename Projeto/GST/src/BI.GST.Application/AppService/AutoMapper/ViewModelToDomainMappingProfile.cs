using AutoMapper;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TipoCursoViewModel, TipoCurso>();
            Mapper.CreateMap<TipoExameViewModel, TipoExame>();
            Mapper.CreateMap<TipoVacinaViewModel, TipoVacina>();
            Mapper.CreateMap<VacinaViewModel, Vacina>();
            Mapper.CreateMap<CursoViewModel, Curso>();
            Mapper.CreateMap<ExameViewModel, Exame>();
            Mapper.CreateMap<FuncionarioViewModel, Funcionario>();
            Mapper.CreateMap<EmpresaUtilizadoraViewModel, EmpresaUtilizadora>();
        }
    }
}
