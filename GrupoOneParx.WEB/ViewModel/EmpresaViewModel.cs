using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrupoOneParx.WEB.ViewModel
{
    public class EmpresaViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho máximo para o campo nome é 255")]
        [Required(ErrorMessage = "O campo nome é obrigátorio")]
        public string Nome { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho máximo para o campo nome é 255")]
        public string Site { get; set; }

        [DisplayName("Quantidade de funcionários")]
        [Required(ErrorMessage = "O campo quantidade de funcionários é obrigátorio")]
        public int QuantidadeFuncionarios { get; set; }
    }
}
