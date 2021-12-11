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
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasOne(p => p.Marca).WithMany(m => m.Produtos);
            builder.HasOne(p => p.Subcategoria).WithMany(e => e.Produtos);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Ativo).HasDefaultValue<bool>(false);
            builder.Property(p => p.Comprimento);
            builder.Property(p => p.Altura);
            builder.Property(p => p.Largura);
            builder.Property(p => p.Peso);
            builder.Property(p => p.DataCadastro).IsRequired();
            builder.Property(p => p.Comprimento);
        }
    }
}
