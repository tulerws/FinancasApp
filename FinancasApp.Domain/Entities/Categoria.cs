using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Entities
{
    public class Categoria
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }

        #region Relacionamentos

        public List<Movimentacao>? Movimentacoes { get; set; }

        #endregion
    }
}
