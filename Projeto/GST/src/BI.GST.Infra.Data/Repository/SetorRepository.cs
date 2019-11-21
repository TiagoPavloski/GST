using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Infra.Data.Context;
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

        public override void Atualizar(Setor obj)
        {
            AgenteAcidenteRepository aa = new AgenteAcidenteRepository();
            AgenteBiologicoRepository ab = new AgenteBiologicoRepository();
            AgenteErgonomicoRepository ae = new AgenteErgonomicoRepository();
            AgenteFisicoRepository af = new AgenteFisicoRepository();
            AgenteQuimicoRepository aq = new AgenteQuimicoRepository();

            //Adiciona lista de agente acidente com o agente acidente Id que foi pego na tela
            List<AgenteAcidente> listAa = new List<AgenteAcidente>();
            foreach (var item in obj.AgenteAcidentes)
            {
                listAa.Add(aa.ObterPorId(item.AgenteAcidenteId));
                //item.Setores.Add(obj);
            }
            obj.AgenteAcidentes = listAa;

            //Adiciona lista de agente biologico com o agente biologico Id que foi pego na tela
            List<AgenteBiologico> listAb = new List<AgenteBiologico>();
            foreach (var item in obj.AgenteBiologicos)
            {
                listAb.Add(ab.ObterPorId(item.AgenteBiologicoId));
                //item.Setores.Add(obj);
            }
            obj.AgenteBiologicos = listAb;

            //Adiciona lista de agente ergonomico com o agente ergonomico Id que foi pego na tela
            List<AgenteErgonomico> listAe = new List<AgenteErgonomico>();
            foreach (var item in obj.AgenteErgonomicos)
            {
                listAe.Add(ae.ObterPorId(item.AgenteErgonomicoId));
                //item.Setores.Add(obj);
            }
            obj.AgenteErgonomicos = listAe;

            //Adiciona lista de agente fisico com o agente fisico Id que foi pego na tela
            List<AgenteFisico> listAf = new List<AgenteFisico>();
            foreach (var item in obj.AgenteFisicos)
            {
                listAf.Add(af.ObterPorId(item.AgenteFisicoId));
            }
            obj.AgenteFisicos = listAf;

            //Adiciona lista de agente quimico com o agente quimico Id que foi pego na tela
            List<AgenteQuimico> listAq = new List<AgenteQuimico>();
            foreach (var item in obj.AgenteQuimicos)
            {
                listAq.Add(aq.ObterPorId(item.AgenteQuimicoId));
                //item.Setores.Add(obj);
            }
            obj.AgenteQuimicos = listAq;

            //Atualiza tabela 
            using (var context = new ProjetoContext())
            {
                context.Database.ExecuteSqlCommand("delete AgenteAcidenteSetor where SetorId = " + obj.SetorId + "");
                context.Database.ExecuteSqlCommand("delete AgenteBiologicoSetor where SetorId = " + obj.SetorId + "");
                context.Database.ExecuteSqlCommand("delete AgenteErgonomicoSetor where SetorId = " + obj.SetorId + "");
                context.Database.ExecuteSqlCommand("delete AgenteFisicoSetor where SetorId = " + obj.SetorId + "");
                context.Database.ExecuteSqlCommand("delete AgenteQuimicoSetor where SetorId = " + obj.SetorId + "");
                foreach (var item in listAa)
                    context.Database.ExecuteSqlCommand("insert into AgenteAcidenteSetor values (" + obj.SetorId + ", " + item.AgenteAcidenteId + ")");
                foreach (var item in listAb)
                    context.Database.ExecuteSqlCommand("insert into AgenteBiologicoSetor values (" + obj.SetorId + ", " + item.AgenteBiologicoId + ")");
                foreach (var item in listAe)
                    context.Database.ExecuteSqlCommand("insert into AgenteErgonomicoSetor values (" + obj.SetorId + ", " + item.AgenteErgonomicoId + ")");
                foreach (var item in listAf)
                    context.Database.ExecuteSqlCommand("insert into AgenteFisicoSetor values (" + obj.SetorId + ", " + item.AgenteFisicoId + ")");
                foreach (var item in listAq)
                    context.Database.ExecuteSqlCommand("insert into AgenteQuimicoSetor values (" + obj.SetorId + ", " + item.AgenteQuimicoId + ")");
            }

            base.Atualizar(obj);
        }


    }
}
