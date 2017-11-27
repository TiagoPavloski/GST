using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.GST.Application.ViewModels
{
	public class CBOViewModel
	{
		public CBOViewModel()
		{
			RiscoCBOs = new List<RiscoCBOViewModel>();
			TipoCursos = new List<TipoCursoViewModel>();
            TipoExames = new List<TipoExameViewModel>();
            TipoVacinas = new List<TipoVacinaViewModel>();

        }
		public int CBOId { get; set; }

        [DisplayName("Função")]
        [Required(ErrorMessage = "Prencher a Função")]
        [MaxLength(70, ErrorMessage = "Máximo de 70 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Código da Função")]
        [Required(ErrorMessage = "Prencher o código")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string CodigoCBO { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(800, ErrorMessage = "Máximo de 800 caracteres")]
        public string Descricao { get; set; }

		public bool Delete { get; set; }

		public virtual List<RiscoCBOViewModel> RiscoCBOs { get; set; }

		public virtual List<TipoCursoViewModel> TipoCursos { get; set; }

		public virtual List<TipoExameViewModel> TipoExames { get; set; }

		public virtual List<TipoVacinaViewModel> TipoVacinas { get; set; }

    }
}