using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
	public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
	{
		public EnderecoConfiguration()
		{
			HasKey(e => e.EnderecoId);

			Property(e => e.Logradouro)
				.HasMaxLength(100)
				.IsRequired();

			Property(e => e.Numero)
			   .HasMaxLength(15)
			   .IsRequired();

			Property(e => e.Complemento)
			  .HasMaxLength(400);

			Property(e => e.Bairro)
				.HasMaxLength(50)
			 .IsRequired();

			Property(e => e.Cidade)
				.HasMaxLength(50)
			 .IsRequired();

			Property(e => e.Pais)
				.HasMaxLength(50)
			 .IsRequired();

			Property(e => e.CEP)
			   .HasMaxLength(8)
			   .IsRequired();

			//HasRequired(e => e.Cliente)
			//	.WithMany(c => c.Endereco)          //Muitos endereços para 1 Cliente
			//	.HasForeignKey(e => e.ClienteId);  //Chave estrangeira de Cliente
		}
	}
}
