using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
  public class CBOConfiguration : EntityTypeConfiguration<CBO>
  {
    public CBOConfiguration()
    {
      HasKey(e => e.CBOId);
    }
  }
}