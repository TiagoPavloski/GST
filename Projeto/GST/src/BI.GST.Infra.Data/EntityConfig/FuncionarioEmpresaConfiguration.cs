using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class FuncionarioEmpresaConfiguration : EntityTypeConfiguration<FuncionarioEmpresa>
    {
        public FuncionarioEmpresaConfiguration()
        {
            HasKey(e => e.FuncionarioEmpresaId);

            Property(e => e.HoraEntrada)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.HoraSaida)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.Admissao)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Admissao)
                .HasMaxLength(10);
        }
    }
}