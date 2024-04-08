using System.ComponentModel.DataAnnotations;

namespace Challenge.API.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public string? Nome { get; set; }
    }
}
