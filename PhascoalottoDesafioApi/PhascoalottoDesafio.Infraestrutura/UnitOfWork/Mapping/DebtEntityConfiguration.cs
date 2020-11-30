using System;
using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhascoalottoDesafio.Infraestrutura.UnitOfWork.Mapping
{
    internal class DebtEntityConfiguration : DbEntityConfiguration<Debt>
    {
        public override void Configure(EntityTypeBuilder<Debt> entity)
        {
            entity.ToTable("Debt");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.DueDate)
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(c => c.InstallmentsCount)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(c => c.OriginalValue)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            entity.Property(c => c.OrientationPhone)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
