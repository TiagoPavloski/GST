using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(e => e.FuncionarioId);

            Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

            Property(e => e.CPF)
                .HasMaxLength(15);

            Property(e => e.RG)
                .HasMaxLength(15);

            Property(e => e.Email)
                .HasMaxLength(100);

            Property(e => e.PIS)
                .HasMaxLength(16);

            Property(e => e.CLT)
                .HasMaxLength(16);

            Property(e => e.Serie)
                .HasMaxLength(16);

            Property(e => e.DataNascimento)
               .HasMaxLength(10);

            Property(e => e.HoraEntrada);

            Property(e => e.HoraSaida);

            Property(e => e.Admissao);
            
            Property(c => c.Status)
                .IsRequired();

        }
    }
}