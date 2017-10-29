using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class CIPAEmpresaRepository : BaseRepository<CIPAEmpresa>, ICIPAEmpresaRepository
    {
        public IEnumerable<CIPAEmpresa> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Empresa.NomeFantasia.Contains(pesquisa) : x.Empresa.NomeFantasia != null) && (x.Delete == false))
                    .OrderBy(u => u.Empresa.NomeFantasia)
                    .Skip((page) * 10)
                    .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Empresa.NomeFantasia.Contains(pesquisa) : x.Empresa.NomeFantasia != null) && (x.Delete == false));
        }

        public override void Adicionar(CIPAEmpresa obj)
        {
            var empresaRepository = new EmpresaRepository();
            var funcionarioRepository = new FuncionarioRepository();
            obj.Empresa = empresaRepository.ObterPorId(obj.EmpresaId);
            var funcionarioCipaRepository = new CIPAEmpresaFuncionarioRepository();

            base.Adicionar(obj);

            foreach (var item in obj.CIPAEmpresaFuncionarios)
            {
                item.Funcionario = funcionarioRepository.ObterPorId(item.FuncionarioId);
                item.CipaEmpresaId = obj.CipaEmpresaID;
                funcionarioCipaRepository.Adicionar(item);
            }
        }

        public override void Atualizar(CIPAEmpresa obj)
        {
            var cipaFuncionarioRepository = new CIPAEmpresaFuncionarioRepository();

            foreach (var funcionario in obj.CIPAEmpresaFuncionarios)
            {
                if (funcionario.CIPAEmpresaFuncionarioId == 0)
                {
                    if (funcionario.CipaEmpresaId == 0)
                    {
                        funcionario.CipaEmpresaId = obj.CipaEmpresaID;
                    }
                    cipaFuncionarioRepository.Adicionar(funcionario);
                }
                else
                    cipaFuncionarioRepository.Atualizar(funcionario);
            }

            base.Atualizar(obj);
        }

    }
}
