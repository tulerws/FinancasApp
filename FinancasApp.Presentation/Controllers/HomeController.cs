using FinancasApp.Domain.Enums;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Presentation.Models.Auth;
using FinancasApp.Presentation.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinancasApp.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMovimentacaoDomainService? _movimentacaoDomainService;

        public HomeController(IMovimentacaoDomainService? movimentacaoDomainService)
        {
            _movimentacaoDomainService = movimentacaoDomainService;
        }

        /// <summary>
        /// Método para abrir a página /Home/Index
        /// </summary>
        public IActionResult Index()
        {
            var model = new PainelPrincipalViewModel();

            try
            {
                var dataAtual = DateTime.Now;
                model.DataInicio = new DateTime(dataAtual.Year, dataAtual.Month, 1);
                model.DataFim = model.DataInicio?.AddMonths(1).AddDays(-1);

                //consultar as movimentações do usuário autenticado no mês atual
                var usuario = JsonConvert.DeserializeObject<UserAuthViewModel>(User.Identity.Name);
                var movimentacoes = _movimentacaoDomainService?
                    .Consultar(model.DataInicio.Value, model.DataFim.Value, usuario.Id.Value);

                //guardando as informações para exibir na página
                model.TotalReceitas = movimentacoes.Where(m => m.Tipo == TipoMovimentacao.Receita).Sum(m => m.Valor);
                model.TotalDespesas = movimentacoes.Where(m => m.Tipo == TipoMovimentacao.Despesa).Sum(m => m.Valor);
                model.Saldo = model.TotalReceitas - model.TotalDespesas;
                model.Situacao = model.Saldo > 0 ? "Saldo Positivo" : model.Saldo < 0 ? "Saldo devedor" : "Saldo nulo";

                //GroupBy para totalizar as contas por cada categoria
                model.GraficoCategorias = movimentacoes
                    .GroupBy(m => m.Categoria?.Nome)
                    .Select(m => new ChartViewModel
                    {
                        Nome = m.Key, //nome da categoria
                        Valor = m.Sum(m => m.Valor)
                    }).ToList();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }
    }
}



