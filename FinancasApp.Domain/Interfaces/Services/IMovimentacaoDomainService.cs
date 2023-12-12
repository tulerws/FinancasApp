using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para a entidade Movimentação
    /// </summary>
    public interface IMovimentacaoDomainService
    {
        void Cadastrar(Movimentacao movimentacao);
        void Atualizar(Movimentacao movimentacao);
        void Excluir(Guid idMovimentacao);

        List<Movimentacao> Consultar(DateTime dataMin, DateTime dataMax, Guid usuarioId);
        Movimentacao ObterPorId(Guid idMovimentacao);
    }
}
