using FinancasApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinancasApp.Presentation.Models.Movimentacoes
{
    /// <summary>
    /// Modelo de dados para o formulário de cadastro de movimentações
    /// </summary>
    public class MovimentacoesConsultaViewModel
    {
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        public DateTime? DataMin { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fim.")]
        public DateTime? DataMax { get; set; }

        /// <summary>
        /// Lista para exibir o resultado da consulta de movimentações
        /// </summary>
        public List<Movimentacao>? ListagemMovimentacoes { get; set; }
    }
}



