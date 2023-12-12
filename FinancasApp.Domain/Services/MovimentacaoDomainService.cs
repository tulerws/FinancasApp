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
    /// Classe para implementar os serviços de domínio de movimentação
    /// </summary>
    public class MovimentacaoDomainService : IMovimentacaoDomainService
    {
        private readonly IMovimentacaoRepository? _movimentacaoRepository;

        public MovimentacaoDomainService(IMovimentacaoRepository? movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void Cadastrar(Movimentacao movimentacao)
        {
            _movimentacaoRepository?.Add(movimentacao);
        }

        public void Atualizar(Movimentacao movimentacao)
        {
            _movimentacaoRepository?.Update(movimentacao);
        }

        public void Excluir(Guid idMovimentacao)
        {
            var movimentacao = ObterPorId(idMovimentacao);
            _movimentacaoRepository?.Delete(movimentacao);
        }

        public List<Movimentacao> Consultar(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            return _movimentacaoRepository?.Get(dataMin, dataMax, usuarioId);
        }

        public Movimentacao ObterPorId(Guid idMovimentacao)
        {
            return _movimentacaoRepository?.GetById(idMovimentacao);
        }
    }
}
