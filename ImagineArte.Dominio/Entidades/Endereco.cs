using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long ClienteId { get; set; }
    }
}
