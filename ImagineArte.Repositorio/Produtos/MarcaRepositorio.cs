using ImagineArte.Dominio.Entidades;
using ImagineArte.Infra.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Produtos
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly EntityFrameworkContexto _dbContext;

        public MarcaRepositorio(EntityFrameworkContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(params Marca[] entidade)
        {
            _dbContext.AddRange(entidade);
            _dbContext.SaveChanges();
        }

        public void Atualizar(params Marca[] entidade)
        {
            _dbContext.UpdateRange(entidade);
            _dbContext.SaveChanges();
        }

        public Marca ObterPorId(long id)
        {
            return _dbContext.Marcas.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Marca> ObterTodas()
        {
            return _dbContext.Marcas;
        }

        public void Remover(params Marca[] entidade)
        {
            _dbContext.RemoveRange(entidade);
            _dbContext.SaveChanges();
        }
    }
}
