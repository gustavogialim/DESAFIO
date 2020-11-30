using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Dominio.Base;
using System;

namespace PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg
{
    public class DebtInstallment : Entity
    {
        public DateTime DueDate { get; set; }

        public decimal FinalValue { get; set; }

        public int DebtId { get; set; }

        public virtual Debt Debt { get; set; }
    }
}
