using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Repositories;

namespace FinancasApp.Presentation
{
    /// <summary>
    /// Classe para configurar as injeções de dependência do projeto
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Método para configurar as injeções de dependência do sistema
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
            services.AddTransient<IMovimentacaoDomainService, MovimentacaoDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
