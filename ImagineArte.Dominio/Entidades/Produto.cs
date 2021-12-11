using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Largura { get; set; }
        public decimal  Altura { get; set; }
        public decimal  Peso { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Marca Marca { get; set; }
        public long  MarcaId { get; set; }
        public virtual  Subcategoria Subcategoria { get; set; }
        public long SubcategoriaId { get; set; }
        public virtual ICollection<Estoque> Estoques { get; set; }
    }
}
