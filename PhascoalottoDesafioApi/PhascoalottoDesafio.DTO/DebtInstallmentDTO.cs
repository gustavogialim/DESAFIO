using System;

namespace PhascoalottoDesafio.DTO
{
    public class DebtInstallmentDTO
    {
        public int Id { get; set; }

        public DateTime DueDate { get; set; }

        public decimal FinalValue { get; set; }
    }
}
