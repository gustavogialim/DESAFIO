using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;

namespace PhascoalottoDesafio.Infraestrutura.Repositories
{
    public class ConfigurationRepository : Repository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(DbUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
