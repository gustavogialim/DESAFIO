using System;
using System.Collections.Generic;

namespace PhascoalottoDesafio.DTO
{
    public class DebtDTO
    {
        public int Id { get; set; }

        public DateTime DueDate { get; set; }

        public int InstallmentsCount { get; set; }

        public int LateDays { get; set; }

        public decimal OriginalValue { get; set; }

        public decimal InterestValue { get; set; }

        public decimal FinalValue { get; set; }

        public decimal ComissionValue { get; set; }

        public string OrientationPhone { get; set; }

        public List<DebtInstallmentDTO> Installments { get; set; }
    }
}
