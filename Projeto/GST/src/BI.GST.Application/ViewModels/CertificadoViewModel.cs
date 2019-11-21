using BI.GST.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BI.GST.Application.ViewModels
{
    public class CertificadoViewModel
    {
       
        public int CertificadoId { get; set; }

        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }

        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }

        [DisplayName("Curso")]
        public int CursoId { get; set; }

        [DisplayName("Curso")]
        public int TipoCursoId { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Preencha o campo descrição")]
        public string Descricao { get; set; }

        [DisplayName("Programatico")]
        [Required(ErrorMessage = "Preencha o campo programático")]
        public string Programatico { get; set; }
        
        [DisplayName("Data de realização")]
        public string DataRealizacao { get; set; }

        [DisplayName("Data de emissão")]    
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string DataEmissao { get; set; }

        [DisplayName("Instituíção ministradora")]
        public int InstituicaoCursoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }

        public string StatusNome { get; set; }

        public bool Delete { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual InstituicaoCurso InstituicaoCurso { get; set; }

    }
}
