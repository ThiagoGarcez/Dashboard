using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.Entidades
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public bool CadastroConfirmado { get; set; }
        public virtual Endereco Endereco { get; set; }
        public long EndrecoId { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
    }
}
