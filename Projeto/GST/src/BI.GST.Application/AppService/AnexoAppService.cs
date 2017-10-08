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
using System.Drawing;
using BI.GST.Infra.CrossCutting.MVCFilters;

namespace BI.GST.Application.AppService
{
    public class AnexoAppService : BaseAppService, IAnexoAppService
    {
        private readonly IAnexoService _anexoService;

        public AnexoAppService(IAnexoService anexoService)
        {
            _anexoService = anexoService;
        }

        public bool Adicionar(AnexoViewModel anexoViewModel)
        {
            var anexo = Mapper.Map<AnexoViewModel, Anexo>(anexoViewModel);

            BeginTransaction();
            _anexoService.Adicionar(anexo);
            Commit();
            return true;
        }

        public bool Atualizar(AnexoViewModel anexoViewModel)
        {
            var anexo = Mapper.Map<AnexoViewModel, Anexo>(anexoViewModel);

            BeginTransaction();
            _anexoService.Atualizar(anexo);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _anexoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _anexoService.Find(e => e.AnexoID == id).Any();
            if (existente)
            {
                BeginTransaction();
                var anexo = _anexoService.ObterPorId(id);
                anexo.Delete = true;
                _anexoService.Atualizar(anexo);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AnexoViewModel> ObterGrid(int page, string pesquisa, int idPPRA)
        {
            return Mapper.Map<IEnumerable<Anexo>, IEnumerable<AnexoViewModel>>(_anexoService.ObterGrid(page, pesquisa,idPPRA));
        }

        public AnexoViewModel ObterPorId(int id)
        {
            return Mapper.Map<Anexo, AnexoViewModel>(_anexoService.ObterPorId(id));
        }

        public IEnumerable<AnexoViewModel> ObterTodos(int idPPRA)
        {
            return Mapper.Map<IEnumerable<Anexo>, IEnumerable<AnexoViewModel>>(_anexoService.ObterTodos(idPPRA));
        }

        public int ObterTotalRegistros(string pesquisa, int idPPRA)
        {
            return _anexoService.ObterTotalRegistros(pesquisa, idPPRA);
        }

        public static byte[] ImagemParaByte(Image imagem)
        {
            return Conversor.ImagemParaByte(imagem);
        }

        public static Image ByteParaImagem(byte[] bytes)
        {
            return Conversor.ByteParaImagem(bytes);
        }
    }
}
