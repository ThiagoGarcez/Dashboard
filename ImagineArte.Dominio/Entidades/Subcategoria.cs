using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Subcategoria
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
        public long CategoriaId { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
