using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Dominio.Base;
using System;
using System.Collections.Generic;

namespace PhascoalottoDesafio.Dominio.Aggregates.DebtAgg
{
    public class Debt : Entity
    {
        public DateTime DueDate { get; set; }

        public int InstallmentsCount { get; set; }

        public decimal OriginalValue { get; set; }

        public string OrientationPhone { get; set; }

        public virtual ICollection<DebtInstallment> Installments { get; private set; } = new List<DebtInstallment>();
    }
}
