using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.API.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public string? Nome { get; set; }
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}
