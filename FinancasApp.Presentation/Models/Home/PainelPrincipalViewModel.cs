namespace FinancasApp.Presentation.Models.Home
{
    /// <summary>
    /// Modelo de dados para a página principal do projeto.
    /// </summary>
    public class PainelPrincipalViewModel
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public decimal? TotalReceitas { get; set; }
        public decimal? TotalDespesas { get; set; }
        public decimal? Saldo { get; set; }
        public string? Situacao { get; set; }

        public List<ChartViewModel>? GraficoCategorias { get; set; }
    }

    /// <summary>
    /// Modelo de dados para os gráficos
    /// </summary>
    public class ChartViewModel
    {
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
    }
}



