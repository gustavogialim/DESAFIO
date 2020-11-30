using PhascoalottoDesafio.Dominio.Base;
using PhascoalottoDesafio.Enum;

namespace PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg
{
    public class Configuration : Entity
    {
        public int MaxInstallments { get; set; }

        public EnumInterestType InterestType { get; set; }

        public decimal InterestValue { get; set; }

        public decimal ComissionPercentage { get; set; }
    }
}
