using System;
using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhascoalottoDesafio.Infraestrutura.UnitOfWork.Mapping
{
    internal class DebtInstallmentEntityConfiguration : DbEntityConfiguration<DebtInstallment>
    {
        public override void Configure(EntityTypeBuilder<DebtInstallment> entity)
        {
            entity.ToTable("DebtInstallment");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.DueDate)
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(c => c.FinalValue)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            entity.HasOne(c => c.Debt)
               .WithMany(c => c.Installments)
               .HasForeignKey(e => e.DebtId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
