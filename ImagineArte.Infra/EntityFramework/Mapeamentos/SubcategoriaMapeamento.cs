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
    public class SubcategoriaMapeamento : IEntityTypeConfiguration<Subcategoria>
    {
        public void Configure(EntityTypeBuilder<Subcategoria> builder)
        {
            builder.ToTable("Subcateogiras");
            builder.HasOne(p => p.Categoria).WithMany(c => c.Subcategorias);
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}