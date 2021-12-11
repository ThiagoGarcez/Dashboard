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
    public class EnderecoMapeamento : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasOne(p => p.Cliente).WithOne(e => e.Endereco);
            builder.Property(p => p.Logradouro).IsRequired();
            builder.Property(p => p.Bairro).IsRequired();
            builder.Property(p => p.Cidade).IsRequired();
            builder.Property(p => p.Uf).IsRequired();
            builder.Property(p => p.CEP).IsRequired();
            builder.Property(p => p.Complemento);
            builder.Property(p => p.Numero);
        }
    }
}
