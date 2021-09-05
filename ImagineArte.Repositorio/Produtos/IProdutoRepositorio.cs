using ImagineArte.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Produtos
{
    public interface IProdutoRepositorio
    {
        void Adicionar(params Produto[] entidade);
        void Atualizar(params Produto[] entidade);
        void Remover(params Produto[] entidade);
        Produto ObterPorId(long id);
        IEnumerable<Produto> ObterTodos();
    }
}
