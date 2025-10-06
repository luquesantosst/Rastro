using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Infra.Mapping
{
    public class ContasAPagarMapping : IEntityTypeConfiguration<ContasAPagar>
    {
        public void Configure(EntityTypeBuilder<ContasAPagar> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCredor)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.LembreteAtivo)
                .IsRequired();

            builder.Property(c => c.DataLembrete);

            builder.Property(c => c.Parcelado)
                .IsRequired();

            builder.Property(c => c.NumeroParcelas);

            builder.Property(c => c.ParcelaAtual);

            builder.Property(c => c.ValorParcela)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ValorTotal)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.Usuario)
            .WithMany(u => u.ContasAPagar)
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
