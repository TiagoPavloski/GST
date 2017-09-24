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
    public class ClassificacaoEfeitoAppService : BaseAppService, IClassificacaoEfeitoAppService
    {
        private readonly IClassificacaoEfeitoService _classificacaoEfeitoService;

        public ClassificacaoEfeitoAppService(IClassificacaoEfeitoService classificacaoEfeitoService)
        {
            _classificacaoEfeitoService = classificacaoEfeitoService;
        }

        public bool Adicionar(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel)
        {
            var classificacaoEfeito = Mapper.Map<ClassificacaoEfeitoViewModel, ClassificacaoEfeito>(classificacaoEfeitoViewModel);
            var duplicado = _classificacaoEfeitoService.Find(e => e.Classificacao == classificacaoEfeito.Classificacao).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _classificacaoEfeitoService.Adicionar(classificacaoEfeito);
                Commit();
                return true;
            }
        }

        public bool Atualizar(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel)
        {
            var classificacaoEfeito = Mapper.Map<ClassificacaoEfeitoViewModel, ClassificacaoEfeito>(classificacaoEfeitoViewModel);

            var duplicado = _classificacaoEfeitoService.Find(e => e.Classificacao == classificacaoEfeito.Classificacao && e.ClassificacaoEfeitoId != classificacaoEfeito.ClassificacaoEfeitoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _classificacaoEfeitoService.Atualizar(classificacaoEfeito);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _classificacaoEfeitoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _classificacaoEfeitoService.Find(e => e.ClassificacaoEfeitoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var classificacaoEfeito = _classificacaoEfeitoService.ObterPorId(id);
                classificacaoEfeito.Delete = true;
                _classificacaoEfeitoService.Atualizar(classificacaoEfeito);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<ClassificacaoEfeitoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<ClassificacaoEfeito>, IEnumerable<ClassificacaoEfeitoViewModel>>(_classificacaoEfeitoService.ObterGrid(page, pesquisa));
        }

        public ClassificacaoEfeitoViewModel ObterPorId(int id)
        {
            return Mapper.Map<ClassificacaoEfeito, ClassificacaoEfeitoViewModel>(_classificacaoEfeitoService.ObterPorId(id));
        }

        public IEnumerable<ClassificacaoEfeitoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClassificacaoEfeito>, IEnumerable<ClassificacaoEfeitoViewModel>>(_classificacaoEfeitoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _classificacaoEfeitoService.ObterTotalRegistros(pesquisa);
        }
    }
}
