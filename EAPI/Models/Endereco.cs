using System.ComponentModel.DataAnnotations;

namespace EAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Logradouro { get; set; }
        [Required]
        [MaxLength(7)]
        public int Numero { get; set; }
    }
}
