using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteFisicoConfiguration : EntityTypeConfiguration<AgenteFisico>
  {
    public AgenteFisicoConfiguration()
    {
      HasKey(e => e.AgenteFisicoId);
    }
  }
}