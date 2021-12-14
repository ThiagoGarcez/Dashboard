using ImagineArte.Dominio.Entidades;
using ImagineArte.Infra.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Organizacao
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly EntityFrameworkContexto _dbContext;

        public DepartamentoRepositorio(EntityFrameworkContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(params Departamento[] entidade)
        {
            _dbContext.AddRange(entidade);
            _dbContext.SaveChanges();
        }

        public void Atualizar(params Departamento[] entidade)
        {
            _dbContext.UpdateRange(entidade);
            _dbContext.SaveChanges();
        }

        public Departamento ObterPorId(long id)
        {
            return _dbContext.Departamentos.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Departamento> ObterTodos()
        {
            return _dbContext.Departamentos;
        }

        public void Remover(params Departamento[] entidade)
        {
            _dbContext.RemoveRange(entidade);
            _dbContext.SaveChanges();
        }
    }
}
