﻿using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class AgentePPRAConfiguration : EntityTypeConfiguration<AgentePPRA>
  {
    public AgentePPRAConfiguration()
    {
      HasKey(e => e.AgentePPRAId);
    }
  }
}