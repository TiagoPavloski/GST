using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class EquipamentoRuidoConfiguration : EntityTypeConfiguration<EquipamentoRuido>
  {
    public EquipamentoRuidoConfiguration()
    {
      HasKey(e => e.EquipamentoRuidoId);
    }
  }
}