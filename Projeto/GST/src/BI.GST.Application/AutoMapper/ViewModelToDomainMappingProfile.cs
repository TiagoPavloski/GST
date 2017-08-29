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

    }
  }
}
