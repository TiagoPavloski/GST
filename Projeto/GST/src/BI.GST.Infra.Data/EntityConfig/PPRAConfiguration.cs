using BI.GST.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BI.GST.Infra.Data.EntityConfig
{
    public class PPRAConfiguration : EntityTypeConfiguration<PPRA>
    {
        public PPRAConfiguration()
        {
            HasKey(e => e.PPRAId);

            HasMany<FuncionarioEmpresa>(m => m.CIPAEleitos)
            .WithMany(t => t.PPRACipaEleitos)
            .Map(
                tm =>
                {
                    tm.MapLeftKey("PPRARefId");
                    tm.MapRightKey("FuncionarioEmpresaCERefId");
                    tm.ToTable("PPRAFuncionarioEmpresaCipaEleitos");
                }
                );
            HasMany<FuncionarioEmpresa>(m => m.CIPASuplentes)
            .WithMany(t => t.PPRACipaSuplentes)
            .Map(
                tm =>
                {
                    tm.MapLeftKey("PPRARefId");
                    tm.MapRightKey("FuncionarioEmpresaCSRefId");
                    tm.ToTable("PPRAFuncionarioEmpresaCipaSuplentes");
                }
                );
            HasMany<FuncionarioEmpresa>(m => m.SESMTEleitos)
            .WithMany(t => t.PPRASesmtEleitos)
            .Map(
                tm =>
                {
                    tm.MapLeftKey("PPRARefId");
                    tm.MapRightKey("FuncionarioEmpresaSERefId");
                    tm.ToTable("PPRAFuncionarioEmpresaSesmtEleitos");
                }
                );
            HasMany<FuncionarioEmpresa>(m => m.SESMTSuplentes)
            .WithMany(t => t.PPRASesmtSuplentes)
            .Map(
                tm =>
                {
                    tm.MapLeftKey("PPRARefId");
                    tm.MapRightKey("FuncionarioEmpresaSSRefId");
                    tm.ToTable("PPRAFuncionarioEmpresaSesmtSuplentes");
                }
                );
        }
    }
}