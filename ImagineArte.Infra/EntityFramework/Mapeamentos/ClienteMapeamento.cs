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
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasOne(p => p.Endereco).WithOne(e => e.Cliente);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(300);
            builder.Property(p => p.CPFCNPJ).IsRequired();
            builder.Property(p => p.Ativo).HasDefaultValue<bool>(false);
            builder.Property(p => p.CadastroConfirmado).HasDefaultValue<bool>(false);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Telefone);
            builder.Property(p => p.Celular).IsRequired();
            builder.Property(p => p.Senha).IsRequired();
        }
    }
}
