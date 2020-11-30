using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;

namespace PhascoalottoDesafio.Infraestrutura.Repositories
{
    public class DebtRepository : Repository<Debt>, IDebtRepository
    {
        public DebtRepository(DbUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
