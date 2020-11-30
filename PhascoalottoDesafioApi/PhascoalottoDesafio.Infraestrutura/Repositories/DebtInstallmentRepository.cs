using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;

namespace PhascoalottoDesafio.Infraestrutura.Repositories
{
    public class DebtInstallmentRepository : Repository<DebtInstallment>, IDebtInstallmentRepository
    {
        public DebtInstallmentRepository(DbUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
