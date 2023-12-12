using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de dominío para a entidade Categoria
    /// </summary>
    public interface ICategoriaDomainService
    {
        List<Categoria> Consultar();
    }
}
