using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteBiologicoConfiguration : EntityTypeConfiguration<AgenteBiologico>
  {
    public AgenteBiologicoConfiguration()
    {
      HasKey(e => e.AgenteBiologicoId);
    }
  }
}