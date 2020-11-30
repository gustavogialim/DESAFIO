using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.Aplicacao.Services.Interfaces;
using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.DTO;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.Transversal.Exceptions;
using System;
using System.Linq;

namespace PhascoalottoDesafio.Aplicacao.Services
{
    public class ConfigurationAppService : IConfigurationAppService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ConfigurationAppService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }


        public ConfigurationDTO GetConfiguration()
        {
            try
            {
                Configuration configuration = _repositoryFactory.ConfigurationRepository.GetAll().First();

                if (configuration == null)
                {
                    throw new AppException("Configuralao não encontrada");
                }

                return configuration.ProjectedAs<ConfigurationDTO>();
            }
            catch (Exception ex)
            {
                throw Throw.Exception(ex);
            }
        }

        public void Dispose()
        {
            _repositoryFactory?.Dispose();
        }
    }
}
