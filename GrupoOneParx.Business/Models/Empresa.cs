using System.ComponentModel.DataAnnotations;

namespace GrupoOneParx.Business.Models
{
    public class Empresa 
    {
         public int Id { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho máximo para o campo nome é 255")]
        [Required(ErrorMessage = "O campo nome é obrigátorio")]
        public string Nome { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho máximo para o campo nome é 255")]
        public string Site { get; set; }


        [Required(ErrorMessage = "O campo quantidade de funcionários é obrigátorio")]
        public int QuantidadeFuncionarios { get; set; }
    }
}
