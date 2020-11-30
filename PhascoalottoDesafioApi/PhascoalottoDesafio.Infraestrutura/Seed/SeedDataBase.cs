using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.Seed.DataBase;

namespace PhascoalottoDesafio.Infraestrutura.Seed
{
    public static class SeedDataBase
    {
        public static void MigrateDatabase(IRepositoryFactory repositoryFactory)
        {
            repositoryFactory.DbUnitOfWork.Database.Migrate();
        }

        public static void SeedDatabase(IRepositoryFactory repositoryFactory)
        {
            var configurationInfra = new ConfigurationBuilder()
                    .AddJsonFile("appsettings-infra.json", optional: true)
                    .Build();

            var connectionString = configurationInfra.GetConnectionString("PhascoalottoDesafio");

            repositoryFactory.DbUnitOfWork.ChangeDatabase(connectionString);

            repositoryFactory.SeedConfiguration();
            repositoryFactory.SeedDebts();
        }
    }
}
