using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhascoalottoDesafio.Infraestrutura.UnitOfWork.Mapping
{
    internal class ConfigurationEntityConfiguration : DbEntityConfiguration<Configuration>
    {
        public override void Configure(EntityTypeBuilder<Configuration> entity)
        {
            entity.ToTable("Configuration");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.MaxInstallments)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(c => c.InterestType)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(c => c.InterestValue)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            entity.Property(c => c.ComissionPercentage)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
