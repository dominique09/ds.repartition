using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DS.Repartition.Models
{
    public class LoginViewModel
    {
        [DisplayName("Nom d'utilisateur")]
        [Required(ErrorMessage = "Le nom d'utilisteur est requis.")]
        [MaxLength(30, ErrorMessage = "Le nom d'utilisateur doit contenir un maximum de 30 caractères.")]
        public string UserName { get; set; }
        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [DisplayName("Se souvenir")]
        public bool RememberMe { get; set; }

    }
}
