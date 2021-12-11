using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Categoria
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual  Departamento Departamento { get; set; }
        public long DepartamentoId { get; set; }
        public virtual ICollection<Subcategoria> Subcategorias { get; set; }
    }
}
