using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgenteCausadorCBOConfiguration : EntityTypeConfiguration<AgenteCausadorCBO>
  {
    public AgenteCausadorCBOConfiguration()
    {
            HasKey(e => e.AgenteCausadorCBOId);

            Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(60);

            Property(c => c.Status)
                      .IsRequired();
        }
  }
}