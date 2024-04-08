using System.ComponentModel.DataAnnotations;

namespace Challenge.API.Dto
{
    public class EmpresaDto
    {

        [Required]
        [Display(Name = "Empresa")]
        public string? Nome { get; set; }
    }
}
