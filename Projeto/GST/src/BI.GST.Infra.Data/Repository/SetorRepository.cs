using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class SetorRepository : BaseRepository<Setor>, ISetorRepository
    {
        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false));
        }

        public IEnumerable<Setor> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false))
                       .OrderBy(u => u.Nome)
                       .Skip((page) * 10)
                       .Take(10);
        }

        public override void Adicionar(Setor obj)
        {
            AgenteAcidenteRepository aa = new AgenteAcidenteRepository();
            AgenteBiologicoRepository ab = new AgenteBiologicoRepository();
            AgenteErgonomicoRepository ae = new AgenteErgonomicoRepository();
            AgenteFisicoRepository af = new AgenteFisicoRepository();
            AgenteQuimicoRepository aq = new AgenteQuimicoRepository();

            //Adiciona lista de agente acidente com o agente acidente Id que foi pego na tela
            List<AgenteAcidente> listAa = new List<AgenteAcidente>();
            foreach (var item in obj.AgenteAcidentes)
                listAa.Add(aa.ObterPorId(item.AgenteAcidenteId));
            obj.AgenteAcidentes = listAa;

            //Adiciona lista de agente biologico com o agente biologico Id que foi pego na tela
            List<AgenteBiologico> listAb = new List<AgenteBiologico>();
            foreach (var item in obj.AgenteBiologicos)
                listAb.Add(ab.ObterPorId(item.AgenteBiologicoId));
            obj.AgenteBiologicos = listAb;

            //Adiciona lista de agente ergonomico com o agente ergonomico Id que foi pego na tela
            List<AgenteErgonomico> listAe = new List<AgenteErgonomico>();
            foreach (var item in obj.AgenteErgonomicos)
                listAe.Add(ae.ObterPorId(item.AgenteErgonomicoId));
            obj.AgenteErgonomicos = listAe;

            //Adiciona lista de agente fisico com o agente fisico Id que foi pego na tela
            List<AgenteFisico> listAf = new List<AgenteFisico>();
            foreach (var item in obj.AgenteFisicos)
                listAf.Add(af.ObterPorId(item.AgenteFisicoId));
            obj.AgenteFisicos = listAf;

            //Adiciona lista de agente quimico com o agente quimico Id que foi pego na tela
            List<AgenteQuimico> listAq = new List<AgenteQuimico>();
            foreach (var item in obj.AgenteQuimicos)
                listAq.Add(aq.ObterPorId(item.AgenteQuimicoId));
            obj.AgenteQuimicos = listAq;

            base.Adicionar(obj);
        }


    }
}
