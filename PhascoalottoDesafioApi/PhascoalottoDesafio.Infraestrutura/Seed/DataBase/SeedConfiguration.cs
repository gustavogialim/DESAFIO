using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using System.Linq;
using PhascoalottoDesafio.Enum;

namespace PhascoalottoDesafio.Infraestrutura.Seed.DataBase
{
    public static class SeedConfigurationExtension
    {
        public static void SeedConfiguration(this IRepositoryFactory repositoryFactory)
        {
            if (!repositoryFactory.ConfigurationRepository.GetAll().Any())
            {
                Configuration configuration = new Configuration();
                configuration.MaxInstallments = 3;
                configuration.InterestType = EnumInterestType.Simples;
                configuration.InterestValue = 0.2M;
                configuration.ComissionPercentage = 10;

                repositoryFactory.ConfigurationRepository.Add(configuration);
                repositoryFactory.ConfigurationRepository.Commit();
            }
        }
    }
}
