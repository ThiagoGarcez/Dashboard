using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Dominio.DTO
{
    public class RespostaPadraoDTO
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public RespostaPadraoDTO()
        {
        }

        public RespostaPadraoDTO(bool sucesso, string mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }
    }
}
