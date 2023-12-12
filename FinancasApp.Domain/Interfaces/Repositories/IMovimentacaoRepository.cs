using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepository : IBaseRepository<Movimentacao>
    {
        /// <summary>
        /// Método para consultar uma lista de movimentações de acordo com:
        /// Data de início de um periodo
        /// Data de fim de um periodo
        /// Id do usuário
        /// </summary>
        List<Movimentacao> Get(DateTime dataMin, DateTime dataMax, Guid usuarioId);
    }
}
