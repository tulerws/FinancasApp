namespace FinancasApp.Presentation.Models.Auth
{
    public class UserAuthViewModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
    }
}
