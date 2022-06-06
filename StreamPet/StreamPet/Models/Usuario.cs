using System.ComponentModel.DataAnnotations;

namespace StreamPet.Models
{
    public class Usuario
    {
        public  int Id{ get; set; }
        [Required(ErrorMessage="Digite o nome de usuário!")]
        private string name{ get; set; }
        [Required(ErrorMessage = "Digite o email de usuário!")]
        private string email{ get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        private string senha{ get; set; }
    }
}
