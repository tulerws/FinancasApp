using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de domínio de categoria
    /// </summary>
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository? _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository? categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> Consultar()
        {
            return _categoriaRepository?.GetAll();
        }
    }
}
