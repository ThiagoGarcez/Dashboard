using ImagineArte.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Infra.EntityFramework.Mapeamentos
{
    public class EstoqueMapeamento : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoques");
            builder.HasOne(p => p.Produto).WithMany(e => e.Estoques);
            builder.Property(p => p.EstoqueDisponivel).IsRequired();
        }
    }
}
