using ImagineArte.Dominio.Entidades;
using ImagineArte.Infra.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Produtos
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly EntityFrameworkContexto _dbContext;

        public ProdutoRepositorio(EntityFrameworkContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(params Produto[] entidade)
        {
            _dbContext.AddRange(entidade);
            _dbContext.SaveChanges();
        }

        public void Atualizar(params Produto[] entidade)
        {
            _dbContext.UpdateRange(entidade);
            _dbContext.SaveChanges();
        }

        public Produto ObterPorId(long id)
        {
            return _dbContext.Produtos.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _dbContext.Produtos; 
        }

        public void Remover(params Produto[] entidade)
        {
            _dbContext.RemoveRange(entidade);
            _dbContext.SaveChanges();
        }
    }
}
