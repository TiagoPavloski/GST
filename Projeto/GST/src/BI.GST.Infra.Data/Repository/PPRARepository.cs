using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class PPRARepository : BaseRepository<PPRA>, IPPRARepository
    {
        public IEnumerable<PPRA> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.EmpresaCliente.NomeFantasia.Contains(pesquisa) : x.EmpresaCliente.NomeFantasia != null) && (x.Delete == false))
                .OrderBy(u => u.EmpresaCliente.NomeFantasia)
                .Skip((page) * 10)
                .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.EmpresaCliente.NomeFantasia.Contains(pesquisa) : x.EmpresaCliente.NomeFantasia != null) && (x.Delete == false));
        }

        public override void Adicionar(PPRA obj)
        {
            var agenteRepository = new AgentePPRARepository();
            var cronogramaRepository = new CronogramaDeAcoesRepository();
            var colaboradorRepository = new ColaboradorRepository();
            var empresaRepository = new EmpresaRepository();
            var meioPropagacaoRepository = new MeioPropagacaoRepository();
            var agenteAmbientalRepository = new AgenteAmbientalRepository();
            var ListAgentePPRA = new List<AgentePPRA>();

            if (obj.ResponsavelAmbientalId > 0)
                obj.ResponsavelAmbiental = (colaboradorRepository.ObterPorId(obj.ResponsavelAmbientalId));

            if (obj.ResponsavelMedicoId > 0)
                obj.ResponsavelMedico = (colaboradorRepository.ObterPorId(obj.ResponsavelMedicoId));

            if (obj.ResponsavelTecnicoId > 0)
                obj.ResponsavelTecnico = (colaboradorRepository.ObterPorId(obj.ResponsavelTecnicoId));

            obj.EmpresaCliente = (empresaRepository.ObterPorId(obj.EmpresaClienteId));

            obj.EmpresaLocal = (empresaRepository.ObterPorId(obj.EmpresaLocalId));


            foreach (var agente in obj.AgentesPPRA)
            {
                agente.AgenteAmbiental = agenteAmbientalRepository.ObterPorId(agente.AgenteAmbientalId);
                agente.MeioPropagacao = meioPropagacaoRepository.ObterPorId(agente.MeioPropagacaoId);
                ListAgentePPRA.Add(agente);
            }

            obj.AgentesPPRA = ListAgentePPRA;

            base.Adicionar(obj);

            foreach (var item in obj.AgentesPPRA)
            {
                item.PPRAId = obj.PPRAId;
                agenteRepository.Adicionar(item);
            }

            foreach (var item in obj.CronogramasDeAcao)
            {
                item.PPRAId = obj.PPRAId;
                cronogramaRepository.Adicionar(item);
            }

        }
    }
}
