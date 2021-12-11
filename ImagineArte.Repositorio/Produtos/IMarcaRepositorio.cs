using ImagineArte.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Produtos
{
    public interface IMarcaRepositorio
    {
        void Adicionar(params Marca[] entidade);
        void Atualizar(params Marca[] entidade);
        void Remover(params Marca[] entidade);
        Marca ObterPorId(long id);
        IEnumerable<Marca> ObterTodas();
    }
}
