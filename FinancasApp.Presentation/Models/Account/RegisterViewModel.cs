using System.ComponentModel.DataAnnotations;

namespace FinancasApp.Presentation.Models.Account
{
    /// <summary>
    /// Modelo de dados para a view /Account/Register
    /// </summary>
    public class RegisterViewModel
    {
        [MinLength(8, ErrorMessage ="Por favor, informe no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage ="Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{8,}$",
            ErrorMessage = "Por favor, informe uma senha com os requisitos citados")]
        [Required(ErrorMessage = "Por favor, informe uma senha.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a sua senha.")]
        public string? SenhaConfirmacao { get; set; }



    }
}
