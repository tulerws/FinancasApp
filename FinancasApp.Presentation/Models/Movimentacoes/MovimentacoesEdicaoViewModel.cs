using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FinancasApp.Presentation.Models.Movimentacoes
{
    public class MovimentacoesEdicaoViewModel
    {
        public Guid Id { get; set; } //campo oculto na página

        [Required(ErrorMessage = "Por favor, informe o nome da movimentação.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a data.")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o tipo da movimentação.")]
        public int? Tipo { get; set; }

        /// <summary>
        /// Propriedade para capturar o ID da categoria selecionada
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione a categoria.")]
        public Guid? CategoriaId { get; set; }

        /// <summary>
        /// Propriedade para popular o campo de seleção de categorias
        /// </summary>
        public List<SelectListItem>? ListagemCategorias { get; set; }
    }
}
