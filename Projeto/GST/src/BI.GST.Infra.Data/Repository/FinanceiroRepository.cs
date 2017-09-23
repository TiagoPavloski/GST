using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class FinanceiroRepository : BaseRepository<Financeiro>, IFinanceiroRepository
    {
        public List<Financeiro> ObterContasPorDataVencimento(string dataInicial, string dataFinal)
        {
            //precisa arrumar esta busca aqui, ainda não consegui terminar
            return new List<Financeiro>();
        }

        public List<Financeiro> ObterContasPorInstituicao(string instituicao)
        {
            return DbSet.Where((x => (x.Instituicao == instituicao) && (x.Delete == false))).ToList<Financeiro>();
        }

        public List<Financeiro> ObterContasPorOperacao(int operacao)
        {
            return DbSet.Where((x => (x.Operacao == operacao) && (x.Delete == false))).ToList<Financeiro>();
        }

        public IEnumerable<Financeiro> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => pesquisa != null ? x.Titulo.Contains(pesquisa) : x.Titulo != null && (x.Delete == false))
               .OrderBy(u => u.Titulo)
               .Skip((page) * 10)
               .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => pesquisa != null ? x.Titulo.Contains(pesquisa) : x.Titulo != null && (x.Delete == false));
        }
    }
}
