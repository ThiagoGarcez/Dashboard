using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Estoque
    {
        public long Id { get; set; }
        public decimal  EstoqueDisponivel { get; set; }
        public virtual Produto Produto { get; set; }
        public long ProdutoId { get; set; }

    }
}
