using ImagineArte.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Repositorio.Organizacao
{
    public interface IDepartamentoRepositorio
    {
        void Adicionar(params Departamento[] entidade);
        void Atualizar(params Departamento[] entidade);
        void Remover(params Departamento[] entidade);
        Departamento ObterPorId(long id);
        IEnumerable<Departamento> ObterTodos();
    }
}
