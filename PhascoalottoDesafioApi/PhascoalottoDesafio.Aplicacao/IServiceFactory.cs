using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.Aplicacao.Services;
using PhascoalottoDesafio.Aplicacao.Services.Interfaces;
using PhascoalottoDesafio.Infraestrutura.Base;

namespace PhascoalottoDesafio.Aplicacao
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private IConfigurationAppService _configurationAppService;
        private IDebtAppService _debtAppService;

        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IConfigurationAppService ConfigurationAppService
        {
            get
            {
                return _configurationAppService ?? (_configurationAppService = new ConfigurationAppService(_repositoryFactory));
            }
        }

        public IDebtAppService DebtAppService
        {
            get
            {
                return _debtAppService ?? (_debtAppService = new DebtAppService(_repositoryFactory));
            }
        }

        public void Dispose()
        {
            _repositoryFactory.Dispose();
            _configurationAppService?.Dispose();
            _debtAppService?.Dispose();
        }
    }
}
