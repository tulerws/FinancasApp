using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Presentation.Models.Account;
using FinancasApp.Presentation.Models.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace FinancasApp.Presentation.Controllers
{
    /// <summary>
    /// Controlador para as páginas da pasta /Account
    /// </summary>
    public class AccountController : Controller
    {
        //atributo
        private readonly IUsuarioDomainService? _usuarioDomainService;

        //construtor para inicializar o atributo (injeção de dependência)
        public AccountController(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        /// <summary>
        /// Método para abrir a página /Account/Login
        /// </summary>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Método para receber o SUBMIT POST da página /Account/Login
        /// </summary>
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //buscar o usuário através do email e da senha
                    var usuario = _usuarioDomainService?.Obter(model.Email, model.Senha);

                    //Autenticar o usuário do AspNet MVC
                    AutenticarUsuario(usuario);

                    //redirecionar para a página /Home/Index
                    return RedirectToAction("Index", "Home");
                }
                catch (ApplicationException e)
                {
                    TempData["MensagemAlerta"] = $"Acesso Negado! {e.Message}";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Erro! {e.Message}";
                }
            }

            return View();
        }

        /// <summary>
        /// Método para abrir a página /Account/Register
        /// </summary>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Método para receber o SUBMIT POST da página /Account/Register
        /// </summary>
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            //verificar se todos os campos passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados enviados pela página
                    var usuario = new Usuario
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = model.Senha
                    };

                    _usuarioDomainService?.CriarUsuario(usuario); //gravando o usuário
                    ModelState.Clear(); //limpar os campos do formulário

                    TempData["MensagemSucesso"] = $"Parabéns {usuario.Nome}, sua conta de usuário foi criada com sucesso!";
                }
                catch (ApplicationException e)
                {
                    TempData["MensagemAlerta"] = $"Alerta! {e.Message}";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Erro! {e.Message}";
                }
            }

            return View();
        }

        /// <summary>
        /// Método para abrir a rota /Account/Logout
        /// </summary>
        public IActionResult Logout()
        {
            //apagar o cookie que contem a autorização do usuário
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirecionar de volta para a página inicial
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Autenticar o usuário no AspNet MVC
        /// </summary>
        private void AutenticarUsuario(Usuario usuario)
        {
            //capturar os dados para autenticar o usuário
            var userAuthViewModel = new UserAuthViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now
            };

            //serializar os dados de autenticação para formato JSON
            var json = JsonConvert.SerializeObject(userAuthViewModel);

            //gravar o Cookie de autenticação do AspNet com os dados do usuário
            //definindo os dados para o cookie de autenticação
            var claimsIdentity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, json)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

            //gravando o cookie de autenticação
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }
    }
}

