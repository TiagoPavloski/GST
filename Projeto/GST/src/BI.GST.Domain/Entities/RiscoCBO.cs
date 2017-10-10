
namespace BI.GST.Domain.Entities
{
  public class RiscoCBO
  {
    public int RiscoCBOId { get; set; }

    public virtual AgenteRiscoCBO AgenteRiscoCBO { get; set; }

    public virtual AgenteCausadorCBO AgenteCausadorCBO { get; set; }

    public virtual FonteRiscoCBO FonteRiscoCBO { get; set; }

    public string Consequencias { get; set; }

    public string MedidasPreventivas { get; set; }

    public bool Delete { get; set; }
  }
}
