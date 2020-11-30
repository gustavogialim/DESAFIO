using System;
using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;

namespace PhascoalottoDesafio.Infraestrutura.Base
{
    public interface IRepositoryFactory : IDisposable
    {
        DbUnitOfWork DbUnitOfWork { get; }
        IConfigurationRepository ConfigurationRepository { get; }
        IDebtRepository DebtRepository { get; }
        IDebtInstallmentRepository DebtInstallmentRepository  { get; }
    }
}
