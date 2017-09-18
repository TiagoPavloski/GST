using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class EquipamentoRuidoConfiguration : EntityTypeConfiguration<EquipamentoRuido>
    {
        public EquipamentoRuidoConfiguration()
        {
            HasKey(e => e.EquipamentoRuidoId);

            Property(c => c.Nome)
            .IsRequired();

            Property(c => c.MarcaEquipamento)
            .IsRequired();

            Property(c => c.ModeloEquipamento)
            .IsRequired();
        }
    }
}