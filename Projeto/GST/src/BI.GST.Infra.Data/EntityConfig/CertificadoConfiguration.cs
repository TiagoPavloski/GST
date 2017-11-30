﻿using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class CertificadoConfiguration : EntityTypeConfiguration<Certificado>
    {
        public CertificadoConfiguration()
        {
            HasKey(e => e.CertificadoId);

            Property(e => e.DataEmissao)
                .IsRequired();

            Property(e => e.Descricao)
                .IsMaxLength()
                .IsRequired();

            Property(e => e.Programatico)
                .IsMaxLength()
                .IsRequired();

        }
    }
}