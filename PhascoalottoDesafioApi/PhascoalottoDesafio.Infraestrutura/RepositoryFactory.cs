using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.Repositories;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;
using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;

namespace PhascoalottoDesafio.Infraestrutura
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DbUnitOfWork _dbUnitOfWork;
        private IConfigurationRepository _configurationRepository;
        private IDebtRepository _debtRepository;
        private IDebtInstallmentRepository _debtInstallmentRepository;

        public RepositoryFactory(DbUnitOfWork DbUnitOfWork)
        {
            _dbUnitOfWork = DbUnitOfWork;
        }

        public DbUnitOfWork DbUnitOfWork
        {
            get
            {
                return _dbUnitOfWork;
            }
        }

        public IConfigurationRepository ConfigurationRepository
        {
            get
            {
                return _configurationRepository ?? (_configurationRepository = new ConfigurationRepository(_dbUnitOfWork));
            }
        }


        public IDebtRepository DebtRepository
        {
            get
            {
                return _debtRepository ?? (_debtRepository = new DebtRepository(_dbUnitOfWork));
            }
        }


        public IDebtInstallmentRepository DebtInstallmentRepository
        {
            get
            {
                return _debtInstallmentRepository ?? (_debtInstallmentRepository = new DebtInstallmentRepository(_dbUnitOfWork));
            }
        }

        public void Dispose()
        {
            _dbUnitOfWork?.Dispose();
            _configurationRepository?.Dispose();
            _debtRepository?.Dispose();
            _debtInstallmentRepository?.Dispose();
        }
    }
}
